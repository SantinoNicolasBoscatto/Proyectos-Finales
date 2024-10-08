using ServiPryntWeb.Models.Entidades;

namespace ServiPryntWeb.Models.DTO
{
    public class TypesListVm
    {
        public IQueryable<TypeProduct>? TypesQueryable { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
