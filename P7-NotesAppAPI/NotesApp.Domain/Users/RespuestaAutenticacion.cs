using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Users
{
    public class RespuestaAutenticacion
    {
        public string? Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
