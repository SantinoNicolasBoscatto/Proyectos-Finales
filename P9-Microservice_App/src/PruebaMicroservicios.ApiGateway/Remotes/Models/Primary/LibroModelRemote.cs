using PruebaMicroservicios.ApiGateway.Interfaces;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Addons;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Interface;
using PruebaMicroservicios.ApiGateway.Remotes.Request;

namespace PruebaMicroservicios.ApiGateway.Remotes.Models.Primary
{
    public class LibroModelRemote : IEnrichable<LibroModelRemote>
    {
        private IAutorRequestRemote? autorRequestRemote;

        public async Task EnrichAsync()
        {
            if (autorRequestRemote == null)
            {
                throw new InvalidOperationException("autorRequestRemote no ha sido inicializado.");
            }
            if (!string.IsNullOrEmpty(AutorId))
            {
                var responseAutor = await autorRequestRemote.GetAutor(AutorId);
                if (responseAutor.resultado)
                {
                    AutorModelRemote = responseAutor.autor;
                }
            }
        }
        public void SetAutorRequestRemote(IAutorRequestRemote autorRequestRemote)
        {
            this.autorRequestRemote = autorRequestRemote;
        }

        public string? Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? AutorId { get; set; }
        public AutorAddonLibroModelRemote? AutorModelRemote { get; set; }

        
    }
}
