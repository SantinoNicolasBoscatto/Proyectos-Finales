using ServiManagement.Models.DTO;
using ServiManagement.Models.Entidades;

namespace ServiManagement.Models.Repositorio.Abstracto
{
    public interface IOrdenesService
    {
        Task<List<OrdenesDTO>> ListaOrdenes(DateTime desde, DateTime hasta, int tecnico = 0);
        Task<List<string>> ListaModelos();
        Task<bool> AgregarOrden(Orden orden);
        Task<List<Marca>> ListaMarcas();
        Task<ListOrdenes> ListaFiltrada(DateTime desde, DateTime hasta, int tecnico, int pageSize, int currentPage = 0);
        Task<Orden> ObtenerPorId(int id);
        Task<bool> ModificarOrden(Orden orden);
        Task<Orden> ObtenerPorNumeroOrden(string ord);
        Task<string> ObtenerTecnico(int id);
    }
}
