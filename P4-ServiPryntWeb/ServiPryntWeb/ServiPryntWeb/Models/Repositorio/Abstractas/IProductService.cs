using ServiPryntWeb.Models.DTO;
using ServiPryntWeb.Models.Entidades;

namespace ServiPryntWeb.Models.Repositorio.Abstractas
{
    public interface IProductService
    {
        bool AddProduct(Productos productos);
        bool UpdateProduct(Productos productos);
        bool DeleteProduct(int productosId);
        ProductosListVm ListProducts(int pageSize, string term = "", bool paging = false, int currentPage = 0,
            (int valueType, int valueStock, int valueOferta) tuple = default, bool oferta = false, bool onlyOfert = false,
            (int valueType, int valueMarca) tupleHome = default);
        Productos GetProduct(int productosId);
    }
}
