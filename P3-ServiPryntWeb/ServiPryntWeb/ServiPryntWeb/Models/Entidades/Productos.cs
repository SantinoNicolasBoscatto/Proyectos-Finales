using System.ComponentModel.DataAnnotations.Schema;

namespace ServiPryntWeb.Models.Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }       
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Precio { get; set; }
        public bool Stock { get; set; }
        public bool Oferta { get; set; }
        public string? Pdf { get; set; }
        public string? Imagen { get; set; }
        public int IdMarca { get; set; }
        public int TypeId { get; set; }
        
        [NotMapped]
        public IFormFile? ImagenFile { get; set; }
        [NotMapped]
        public IFormFile? PdfFile { get; set; }

        public Marcas? Marca { get; set; }
        //public Ofertas? Oferta { get; set; }
        public TypeProduct? TypeProduct { get; set; }
    }
}
