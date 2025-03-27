using EventBus.EventQueue;
using EventBus.Interfaces;
using PruebaMicroservicios.Libro.Application;
using PruebaMicroservicios.Libro.Infrastructure;
using PruebaMicroservicios.Libro.Infrastructure.IntegrationEvents;
using PruebaMicroservicios.Libro.Presentation;
using PruebaMicroservicios.Libro.Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();

builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices();

var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IRabbitEventBus>();
await eventBus.Suscribe<TestEventQueue, TestEventHandler>();

app.MapGrpcService<LibroService>();
app.MapGrpcReflectionService();

app.Run();

