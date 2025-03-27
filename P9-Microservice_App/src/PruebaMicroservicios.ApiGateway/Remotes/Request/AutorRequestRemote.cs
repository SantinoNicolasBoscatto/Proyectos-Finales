using PruebaMicroservicios.ApiGateway.Interfaces;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Addons;
using System.Text.Json;

namespace PruebaMicroservicios.ApiGateway.Remotes.Request
{
    public class AutorRequestRemote : IAutorRequestRemote
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<AutorRequestRemote> _logger;
        public AutorRequestRemote(IHttpClientFactory httpClient, ILogger<AutorRequestRemote> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, AutorAddonLibroModelRemote? autor, string? ErrorMessage)> GetAutor(string AutorId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("AutorService");
                var response = await cliente.GetAsync($"/api/autor/{AutorId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonDocument = JsonDocument.Parse(content);
                    if (jsonDocument.RootElement.TryGetProperty("Data", out JsonElement dataElement))
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var resultado = JsonSerializer.Deserialize<AutorAddonLibroModelRemote>(dataElement, options);
                        return (true, resultado, null);
                    }
                    
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
