using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ModeloDeDominio
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NumeroPokedex { get; set; }
        public string DescripcionDePokemon { get; set; }
        public bool shiny { get; set; }
        public string Sprite { get; set; }
        public string Sprite3d { get; set; }
        public Tipo TipoDeElemento { get; set; }
        public Tipo TipoDeElemento2 { get; set; }
        public Tipo Debilidad { get; set; }
        public StatsBase EstadisticasBase { get; set; }
        public Naturaleza Naturaleza {get; set; }
        public Habilidad Habilidad { get; set; }
        public string GritoPokemon { get; set; }
        public Pokemon()
        {
            this.TipoDeElemento = new Tipo();
            this.TipoDeElemento2 = new Tipo();
            this.Debilidad = new Tipo();
            this.EstadisticasBase = new StatsBase();
            this.Naturaleza = new Naturaleza();
            this.Habilidad = new Habilidad();        }

    }
}
