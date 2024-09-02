using NascarPage.Entitys;

namespace NascarPage.DTOs
{
    public class LecturaRegularDTO
    {
        public int Id { get; set; }     
        public int Wins { get; set; }
        public int Poles { get; set; }
        public int Top5s { get; set; }
        public int Top10s { get; set; }
        public int DNF { get; set; }
        public int LapsLead { get; set; }
        public int Puntos { get; set; }
        public int Behind { get; set; }
        public PilotoRegularTablaDTO Piloto { get; set; } = null!;
        public MarcaRegularTablaDTO Marca { get; set; } = null!;

    }

    public class MarcaRegularTablaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Foto { get; set; } = null!;
    }

    public class PilotoRegularTablaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Numero { get; set; }
    }
}
