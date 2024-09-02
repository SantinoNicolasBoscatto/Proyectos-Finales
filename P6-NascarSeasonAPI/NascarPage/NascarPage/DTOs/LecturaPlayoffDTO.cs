using NascarPage.Entitys;

namespace NascarPage.DTOs
{
    public class LecturaPlayoffDTO
    {
        public int Id { get; set; }   
        public int PuntosPlayoff { get; set; }
        public int BehindPlayoff { get; set; }
        public PilotoRegularTablaDTO Piloto { get; set; } = null!;
        public MarcaRegularTablaDTO Marca { get; set; } = null!;

        public bool Clasificado16avos { get; set; }
        public bool Clasificado12avos { get; set; }
        public bool Clasificado8avos { get; set; }
        public bool ClasificadoFinal4 { get; set; }
    }
}
