using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDominio
{
    public class Tipo
    {
        public string TipoPokemon { get; set; }
        public int Id { get; set; }
        public string ImagenTipo { get; set; }
        public override string ToString()
        {
            return TipoPokemon;
        }
    }
}
