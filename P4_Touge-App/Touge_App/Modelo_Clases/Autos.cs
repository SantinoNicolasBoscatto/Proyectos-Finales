using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Clases
{
    public class Autos
    {
        public string NombreModelo { get; set; }
        public int Anio { get; set; }
        public string PaisFabricacion { get; set; }
        public Marca MarcaAuto { get; set; }
        public int HP { get; set; }
        public int Torque { get; set; }
        public int Peso { get; set; }
        public int Tanque { get; set; }
        public double RelacionPesoPotencia { get; set; }
        public double TopSpeed { get; set; }
        public string ImagenAuto { get; set; }
        public string ImagenAutoSecundaria { get; set; }
        public string ImagenAutoTres { get; set; }
        public string ImagenAutoCuatro { get; set; }
        public string ImagenAutoCinco { get; set; }
        public string Categoria { get; set; }
        public string Traccion { get; set; }
        public string Aspiracion { get; set; }
        public double Kilometraje { get; set; }
        public string Piloto { get; set; }

        public Autos()
        {
            this.MarcaAuto = new Marca();
        }
    }

    public class MiAuto
    {
        public int Hp { get; set; }
        public int Peso { get; set; }
        public int Torque { get; set; }
        public double PesoPotencia { get; set; }
        public string Traccion { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public bool Aceite { get; set; }
        public bool Motor { get; set; }
        public bool Mantenimiento { get; set; }
        public bool Lavado { get; set; }
        public bool Repro { get; set; }
        public string Asp { get; set; }
        public int TanqueActual { get; set; }
        public int TanqueTotal { get; set; }
        public int GomasSemiSlick { get; set; }
        public int GomasWet { get; set; }
    }
}
