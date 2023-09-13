using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Clases
{
    public class Alquiler
    {
        public int NumeroRegistro { get; set; }
        public int PrecioDepartamento { get; set; }
        public int CantidadDormitorios { get; set; }
        public int CantidadSalasEstar { get; set; }
        public int CantidadDuchas { get; set; }
        public int CantidadGarajes { get; set; }
        public string NombreAlquiler { get; set; }
        public string ImagenAlquiler { get; set; }
        public bool Estado { get; set; }
    }
}
