using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Mapper;
using NotesApp.Application;
using MediatR;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUser;
using NotesApp.Application.Contracts;
using NotesApp.Repository;
using NotesApp.Domain;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NotesApp.Domain.Users;
using NotesApp.Security;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Contracts.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextNotes>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});


builder.Services.AddAuthentication().AddJwtBearer(opt =>
{
    opt.MapInboundClaims = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]!))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configuración de contraseñas (opcional)
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    // Configuración de bloqueo de cuentas
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    // Configuración de usuarios
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<DbContextNotes>().AddDefaultTokenProviders();
builder.Services.AddScoped<UserManager<IdentityUser>>();
builder.Services.AddScoped<SignInManager<IdentityUser>>();
builder.Services.AddScoped<ISecurityTokenConstructor, SecurityTokenConstructor>();

builder.Services.AddMapperServices();
builder.Services.AddApplicationServices();
builder.Services.AddRepositoryServices();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("/", async (IMediator mediator, UserManager<IdentityUser> userManager) =>
{
    return await mediator.Send(new GetNotesPerUserQuery() { IdentityUserId = "d6d94155-1a3f-4ce5-a819-eba202ed823d" });
}).WithName("GetNotes").WithOpenApi();


app.MapPost("/registrar", async ([FromBody] CredencialesUsuario cred, UserManager<IdentityUser> userManager, 
    ISecurityTokenConstructor securityTokenConstructor) =>
{
    var usuario = new IdentityUser { Email = cred.Email, UserName = cred.Email };
    var resultado = await userManager.CreateAsync(usuario, cred.Password);

    if (resultado.Succeeded)
    {
        var token = securityTokenConstructor.ConstruirToken(cred);
        return Results.Ok(token);
    }
    else return Results.BadRequest(resultado.Errors); 

}).WithName("Registrarse").WithOpenApi();

app.Run();
