using ServiPryntWeb.Models.Entidades;

namespace ServiPryntWeb.Models.DTO
{
    public class MarcasListVm
    {
        public IQueryable<Marcas>? MarcasQueryable { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
