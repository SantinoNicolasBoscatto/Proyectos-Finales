using System.ComponentModel.DataAnnotations;

namespace NascarPage.Entitys
{
    public class PosicionPlayoff
    {
        public int Id { get; set; }
        public Piloto Piloto { get; set; } = null!;
        public Marca Marca { get; set; } = null!;
        public int PilotoId { get; set; }
        public int MarcaId { get; set; }

        public int PuntosPlayoff { get; set; }
        [Required]
        public int PuntosExtra { get; set; }
        public int BehindPlayoff { get; set; }

        public bool Clasificado16avos { get; set; }
        public bool Clasificado12avos { get; set; }
        public bool Clasificado8avos { get; set; }
        public bool ClasificadoFinal4 { get; set; }

        public PosicionCampeonatoRegular Regular { get; set; } = null!;

    }
}
