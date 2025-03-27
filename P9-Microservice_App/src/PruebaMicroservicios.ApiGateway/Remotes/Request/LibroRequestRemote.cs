using PruebaMicroservicios.ApiGateway.Interfaces;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Addons;
using System.Text.Json;

namespace PruebaMicroservicios.ApiGateway.Remotes.Request
{
    public class LibroRequestRemote : ILibroRequestRemote
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<AutorRequestRemote> _logger;
        public LibroRequestRemote(IHttpClientFactory httpClient, ILogger<AutorRequestRemote> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, List<LibroAddonAutorModelRemote>? libro, string? ErrorMessage)> GetAllLibroByAutor(string AutorId)
        {
            var cliente = _httpClient.CreateClient("LibroService");
            var response = await cliente.GetAsync($"/api/libro/autor/{AutorId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonDocument = JsonDocument.Parse(content);
                if (jsonDocument.RootElement.TryGetProperty("Data", out JsonElement dataElement))
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<List<LibroAddonAutorModelRemote>>(dataElement, options);
                    return (true, resultado, null);
                }

            }
            return (false, null, response.ReasonPhrase);
        }
    }
}
