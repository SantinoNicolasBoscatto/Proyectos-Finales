using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Clases
{
    public class Economia
    {
        public int MiDinero { get; set; }
    }

    public class Ropa
    {
        public int Id { get; set; }
        public int Precio { get; set; }
        public string NombreRopa { get; set; }
        public string Imagen { get; set; }
        public bool Comprado { get; set; }
    }
        //Sitio =   https://www.beforward.jp/
}
