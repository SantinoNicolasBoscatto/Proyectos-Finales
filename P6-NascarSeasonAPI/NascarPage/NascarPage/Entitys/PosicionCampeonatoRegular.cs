namespace NascarPage.Entitys
{
    public class PosicionCampeonatoRegular
    {
        public int Id { get; set; }
        public int PilotoId { get; set; }
        public int MarcaId { get; set; }
        public int Wins { get; set; }
        public int Poles { get; set; }
        public int Top5s { get; set; }
        public int Top10s { get; set; }
        public int DNF { get; set; }
        public int LapsLead { get; set; }
        public int Puntos { get; set; }

        public int Behind { get; set; }


       

        public Piloto Piloto { get; set; } = null!;
        public Marca Marca { get; set; } = null!;
        public PosicionPlayoff Playoff { get; set; } = null!;
    }
}
