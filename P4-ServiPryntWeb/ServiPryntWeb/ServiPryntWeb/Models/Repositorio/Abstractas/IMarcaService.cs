using ServiPryntWeb.Models.DTO;
using ServiPryntWeb.Models.Entidades;

namespace ServiPryntWeb.Models.Repositorio.Abstractas
{
    public interface IMarcaService
    {
        bool AddMarca(Marcas marca);
        bool UpdateMarca(Marcas marca);
        bool DeleteMarca(int marcaId);
        MarcasListVm ListMarcas(int pageSize = 0, string term = "", bool paging = false, int currentPage = 0);
        Marcas GetMarca(int MarcaId);
    }
}
