using ServiManagement.Models.Entidades;

namespace ServiManagement.Models.DTO
{
    public class ListOrdenes
    {
        public ICollection<Orden> ListaOrdenes { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
