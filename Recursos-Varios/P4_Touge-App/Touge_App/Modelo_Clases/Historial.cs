using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Clases
{
    public class Historial
    {

        public string Circuito { get; set; }
        [System.ComponentModel.DisplayName("Yo")]
        public string PilotoA { get; set; }
        [System.ComponentModel.DisplayName("Rival")]
        public string PilotoB { get; set; }
        [System.ComponentModel.DisplayName("Mi Auto")]
        public string AutoA { get; set; }
        [System.ComponentModel.DisplayName("Auto Rival")]
        public string AutoB { get; set; }
        public string Ganador { get; set; }
        public string Perdedor { get; set; }
        public string Tiempo { get; set; }
        public string Clase { get; set; }
        public string Clima { get; set; }
        public string Modalidad { get; set; }
        public string Promocion { get; set; }
    }
}
