using PruebaMicroservicios.ApiGateway.Remotes.Models.Addons;

namespace PruebaMicroservicios.ApiGateway.Interfaces
{
    public interface IAutorRequestRemote
    {
        Task<(bool resultado, AutorAddonLibroModelRemote? autor, string? ErrorMessage)> GetAutor(string AutorId);
    }
}
