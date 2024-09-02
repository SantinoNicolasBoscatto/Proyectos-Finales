using ServiPryntWeb.Models.DTO;
using ServiPryntWeb.Models.Entidades;

namespace ServiPryntWeb.Models.Repositorio.Abstractas
{
    public interface ITypeProductService
    {
        bool AddType(TypeProduct type);
        bool UpdateType(TypeProduct type);
        bool DeleteType(int typeId);
        TypesListVm ListTypes(int pageSize = 0, string term = "", bool paging = false, int currentPage = 0);
        TypeProduct GetTypeProduct(int TypeId);
    }
}
