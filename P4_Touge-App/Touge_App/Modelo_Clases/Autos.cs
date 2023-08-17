using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Clases
{
    class Autos
    {
        public string NombreModelo { get; set; }
        public int Anio { get; set; }
        public string PaisFabricacion { get; set; }
        public Marca Marca { get; set; }
        public int HP { get; set; }
        public int Torque { get; set; }
        public int Peso { get; set; }
        public float RelacionPesoPotencia { get; set; }
        public float TopSpeed { get; set; }
        public string ImagenAuto { get; set; }
        public string ImagenAutoSecundaria { get; set; }
        public string Categoria { get; set; }
        public string Traccion { get; set; }
        public double Kilometraje { get; set; }
    }
}
