using PruebaMicroservicios.ApiGateway.Remotes.Models.Addons;

namespace PruebaMicroservicios.ApiGateway.Interfaces
{
    public interface ILibroRequestRemote
    {
        Task<(bool resultado, List<LibroAddonAutorModelRemote>? libro, string? ErrorMessage)> GetAllLibroByAutor(string AutorId);
    }
}
