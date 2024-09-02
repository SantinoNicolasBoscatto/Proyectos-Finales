using System.ComponentModel.DataAnnotations;

namespace NascarPage.Entitys
{
    public class Marca
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public string Foto { get; set; } = null!;
        public List<Auto> ListaAutos { get; set; } = null!;
        public PosicionManofactura PosicionManofactura { get; set; } = null!;
    }
}
