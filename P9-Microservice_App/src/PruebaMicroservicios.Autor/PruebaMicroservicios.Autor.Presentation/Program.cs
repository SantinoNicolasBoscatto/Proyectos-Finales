using PruebaMicroservicios.Autor.Application;
using PruebaMicroservicios.Autor.Infrastructure;
using PruebaMicroservicios.Autor.Presentation;
using PruebaMicroservicios.Autor.Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection(); 

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices();

var app = builder.Build();

app.MapGrpcService<AutorService>();
app.MapGrpcReflectionService();

app.Run();
