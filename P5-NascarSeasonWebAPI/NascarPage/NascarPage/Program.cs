using Microsoft.EntityFrameworkCore;
using NascarPage;
using NascarPage.Repositorio;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
.AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var origenesPermitidos = builder.Configuration.GetValue<string>("Origenes")!;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        //config.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Negocio>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

builder.Services.AddScoped<IPilotoService, PilotoService>();
builder.Services.AddScoped<IAutoService, AutoService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IPistaService, PistaService>();
builder.Services.AddScoped<ICampeonService, CampeonService>();
builder.Services.AddScoped<ICarreraService, CarreraService>();
builder.Services.AddScoped<ITablaService, TablasService>();
builder.Services.AddScoped<INacionalidadService, NacionalidadService>();
builder.Services.AddScoped<IGaleriaService, GaleriaService>();
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program));





var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
