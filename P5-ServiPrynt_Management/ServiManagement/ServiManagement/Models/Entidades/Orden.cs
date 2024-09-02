using System.ComponentModel.DataAnnotations;

namespace ServiManagement.Models.Entidades
{
    public class Orden
    {
        public int Id { get; set; }
        public int Tecnico { get; set; }
        [Required(ErrorMessage = "El campo Numero De Orden es requerido y debe ser unico")]
        public string NumeroDeOrden { get; set; }
        [Required(ErrorMessage = "El campo Modelo es requerido")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime FechaDeCarga { get; set; }

        [Required(ErrorMessage = "El campo Monto es obligatorio")]
        public int Monto { get; set; }
        public Marca Marca { get; set; }
        public Usuario Usuario { get; set; }
    }
}
