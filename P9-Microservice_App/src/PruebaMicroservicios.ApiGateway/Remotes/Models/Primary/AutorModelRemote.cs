using PruebaMicroservicios.ApiGateway.Interfaces;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Addons;
using PruebaMicroservicios.ApiGateway.Remotes.Models.Interface;
using PruebaMicroservicios.ApiGateway.Remotes.Request;

namespace PruebaMicroservicios.ApiGateway.Remotes.Models.Primary
{
    public class AutorModelRemote : IEnrichable<AutorModelRemote>
    {
        private ILibroRequestRemote? libroRequestRemote;
        public async Task EnrichAsync()
        {
            if (libroRequestRemote == null)
            {
                throw new InvalidOperationException("libroRequestRemote no ha sido inicializado.");
            }
            if (!string.IsNullOrEmpty(Id))
            {
                var responseBook = await libroRequestRemote.GetAllLibroByAutor(Id);
                if (responseBook.resultado)
                {
                    LibrosLista.AddRange(responseBook.libro!);
                }
            }
        }

        public void SetLibroRequestRemote(ILibroRequestRemote libroRequestRemote)
        {
            this.libroRequestRemote = libroRequestRemote;
        }

        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime Born { get; set; }
        public List<LibroAddonAutorModelRemote> LibrosLista { get; set; } = new List<LibroAddonAutorModelRemote>();      
    }
}
