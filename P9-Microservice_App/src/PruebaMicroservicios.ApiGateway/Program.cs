using PruebaMicroservicios.ApiGateway.Interfaces;
using PruebaMicroservicios.ApiGateway.Middlewares;
using PruebaMicroservicios.ApiGateway.Remotes.Request;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("AutorService", cfg =>
{
    cfg.BaseAddress = new Uri(builder.Configuration["Services:Autores"]!);
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler();
    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
    return handler;
});
builder.Services.AddHttpClient("LibroService", (cfg) =>
{
    cfg.BaseAddress = new Uri(builder.Configuration["Services:Libros"]!);
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler();
    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
    return handler;
});

builder.Services.AddTransient<IAutorRequestRemote, AutorRequestRemote>();
builder.Services.AddTransient<ILibroRequestRemote, LibroRequestRemote>();


builder.Services.AddReverseProxy()
.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
.ConfigureHttpClient((context, handler) =>
{
    handler.SslOptions.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
});




var app = builder.Build();
app.UseMiddleware<RotutingMiddleware>();
app.MapReverseProxy();
app.Run();
