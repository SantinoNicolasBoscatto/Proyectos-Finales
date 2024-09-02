using System.ComponentModel.DataAnnotations;

namespace ServiPryntWeb.Models.Entidades
{
    public class Usuario
    {
        
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El usuario es requerido.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string? Password { get; set; }
    }
}
