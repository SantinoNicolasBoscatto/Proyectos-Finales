using PruebaMicroservicios.ApiGateway.Interfaces;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Interface;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Primary;
using System.Text;
using System.Text.Json;

namespace PruebaMicroservicios.ApiGateway.Middlewares
{
    public class RotutingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAutorRequestRemote autorRequestRemote;
        private readonly ILibroRequestRemote libroRequestRemote;
        private readonly IServiceProvider serviceProvider;

        public RotutingMiddleware(RequestDelegate siguiente, IAutorRequestRemote autorRequestRemote, ILibroRequestRemote libroRequestRemote, IServiceProvider serviceProvider)
        {
            _next = siguiente;
            this.autorRequestRemote = autorRequestRemote;
            this.libroRequestRemote = libroRequestRemote;
            this.serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using var streamOriginal = context.Response.Body;
            using var memoriaStream = new MemoryStream();
            context.Response.Body = memoriaStream;

            await _next(context);

            var path = context.Request.Path.Value;
            memoriaStream.Seek(0, SeekOrigin.Begin);
            var content = new StreamReader(memoriaStream).ReadToEnd();
            var jsonDocument = JsonDocument.Parse(content);

            if (context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
            {
                if (path!.Contains("/api/libro"))
                {
                    await ProcessJsonAsync<LibroModelRemote>(streamOriginal, memoriaStream, jsonDocument, serviceProvider);
                }

                else if (path!.Contains("/api/autor") && !path.Contains("libro"))
                {
                    await ProcessJsonAsync<AutorModelRemote>(streamOriginal, memoriaStream, jsonDocument, serviceProvider);
                }
            }


            memoriaStream.Seek(0, SeekOrigin.Begin);
            await memoriaStream.CopyToAsync(streamOriginal);
            context.Response.Body = streamOriginal;
        }
        private async Task<MemoryStream> ProcessJsonAsync<T>(Stream streamOriginal, MemoryStream memoriaStream, JsonDocument jsonDocument, IServiceProvider serviceProvider)
            where T : class, IEnrichable<T>, new()
        {
            object result = new List<T>(); // Lista vacía si no hay datos

            if (jsonDocument.RootElement.TryGetProperty("Data", out JsonElement dataElement))
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                if (dataElement.ValueKind == JsonValueKind.Array)
                {
                    var items = JsonSerializer.Deserialize<List<T>>(dataElement, options) ?? new List<T>();

                    // Inyectar dependencias manualmente
                    foreach (var item in items)
                    {
                        InjectDependencies(item, serviceProvider);
                        await item.EnrichAsync();
                    }

                    result = items;
                }
                else
                {
                    var item = JsonSerializer.Deserialize<T>(dataElement, options);
                    if (item != null)
                    {
                        InjectDependencies(item, serviceProvider);
                        await item.EnrichAsync();
                        result = item;
                    }
                }
            }

            // Serializar y escribir en el stream
            var resultString = JsonSerializer.Serialize(result);
            memoriaStream.SetLength(0);
            var resultBytes = System.Text.Encoding.UTF8.GetBytes(resultString);
            await streamOriginal.WriteAsync(resultBytes, 0, resultBytes.Length);

            return memoriaStream;
        }
        private void InjectDependencies<T>(T item, IServiceProvider serviceProvider)
        {
            if (item is LibroModelRemote libro)
            {
                var autorRequest = serviceProvider.GetRequiredService<IAutorRequestRemote>();
                libro.SetAutorRequestRemote(autorRequest);
            }
            else if (item is AutorModelRemote autor)
            {
                var libroRequest = serviceProvider.GetRequiredService<ILibroRequestRemote>();
                autor.SetLibroRequestRemote(libroRequest);
            }
        }
    }
}
