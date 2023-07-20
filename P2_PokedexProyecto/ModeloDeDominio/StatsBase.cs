using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDominio
{
    public class StatsBase
    {
        public int HP { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int AtaqueEspecial { get; set; }
        public int DefensaEspecial { get; set; }
        public int Velocidad { get; set; }
    }
}
