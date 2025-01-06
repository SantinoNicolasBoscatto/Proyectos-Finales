using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NotesApp.Application.Contracts.Security;
using NotesApp.Data;
using NotesApp.Security;
using System.Text;
using NotesApp.Mapper;
using NotesApp.Application;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Net;
using System.Security.Claims;
using NotesApp.Repository.Service;
using NotesApp.PresentationController.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextNotes>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(b =>
    {
        b.WithOrigins(builder.Configuration["alloworigins"]!).AllowAnyMethod().AllowAnyHeader();
    });
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["keyjwt"]!))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("EsAdmin", politica => politica.RequireClaim("EsAdmin")); 
});

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

builder.Services.AddMapperServices();
builder.Services.AddApplicationServices();
builder.Services.AddRepositoryServices();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
