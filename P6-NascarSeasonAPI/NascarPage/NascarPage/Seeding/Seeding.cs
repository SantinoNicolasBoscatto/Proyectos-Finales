using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NascarPage.Entitys;

namespace NascarPage.Seeding
{
    public static class Seeding
    {
        public static void CrearNacionalidad(EntityTypeBuilder<Nacionalidad> builder)
        {
            builder.HasData
            (
                new Nacionalidad
                {
                    Id = 1,
                    Nombre = "Estados Unidos",
                    Bandera = ""
                },
                new Nacionalidad
                {
                    Id = 2,
                    Nombre = "Alemania",
                    Bandera = ""
                },
                new Nacionalidad
                {
                    Id = 3,
                    Nombre = "Inglaterra",
                    Bandera = ""
                },
                new Nacionalidad
                {
                    Id = 4,
                    Nombre = "Mexico",
                    Bandera = ""
                },
                new Nacionalidad
                {
                    Id = 5,
                    Nombre = "Argentina",
                    Bandera = ""
                },
                new Nacionalidad
                {
                    Id = 6,
                    Nombre = "Francia",
                    Bandera = ""
                },
                new Nacionalidad
                {
                    Id = 7,
                    Nombre = "Italia",
                    Bandera = ""
                },
                new Nacionalidad
                {
                    Id = 8,
                    Nombre = "Dinamarca",
                    Bandera = ""
                }
            );
        }
        public static void CrearMarcas(EntityTypeBuilder<Marca> builder)
        {
            builder.HasData
            (
                new Marca
                {
                    Id = 1,
                    Nombre = "Chevrolet",
                    Foto = ""
                },
                new Marca
                {
                    Id = 2,
                    Nombre = "Ford",
                    Foto = ""
                },
                new Marca
                {
                    Id = 3,
                    Nombre = "Dodge",
                    Foto = ""
                },
                new Marca
                {
                    Id = 4,
                    Nombre = "Toyota",
                    Foto = ""
                }
            );
        }
        public static void CrearPilotos(EntityTypeBuilder<Piloto> builder)
        {
            builder.HasData
            (
                new Piloto
                {
                    Id = 1,
                    Nombre = "Milo Davis",
                    Numero = "00",
                    FotoPiloto = "",
                    CarrerasGanadas = 2,
                    Poles = 4,
                    Top5s = 10,
                    Top10s = 19,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 28
                },
                new Piloto
                {
                    Id = 2,
                    Nombre = "Ryan Smith",
                    Numero = "1",
                    FotoPiloto = "",
                    CarrerasGanadas = 49,
                    Poles = 37,
                    Top5s = 108,
                    Top10s = 153,
                    Campeonatos = 2,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 40
                },
                new Piloto
                {
                    Id = 3,
                    Nombre = "Hans Muller",
                    Numero = "2",
                    FotoPiloto = "",
                    CarrerasGanadas = 8,
                    Poles = 1,
                    Top5s = 24,
                    Top10s = 59,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 2,
                    Edad = 39
                },
                new Piloto
                {
                    Id = 4,
                    Nombre = "Jim Anderson",
                    Numero = "5",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 0,
                    Top10s = 2,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 22
                },
                new Piloto
                {
                    Id = 5,
                    Nombre = "Zack Taylor",
                    Numero = "7",
                    FotoPiloto = "",
                    CarrerasGanadas = 31,
                    Poles = 43,
                    Top5s = 67,
                    Top10s = 90,
                    Campeonatos = 2,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 32
                },
                new Piloto
                {
                    Id = 6,
                    Nombre = "Ethan Brown",
                    Numero = "9",
                    FotoPiloto = "",
                    CarrerasGanadas = 4,
                    Poles = 2,
                    Top5s = 11,
                    Top10s = 23,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 27
                },
                new Piloto
                {
                    Id = 7,
                    Nombre = "Michael Mrucz",
                    Numero = "10",
                    FotoPiloto = "",
                    CarrerasGanadas = 2,
                    Poles = 2,
                    Top5s = 4,
                    Top10s = 8,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 32
                },
                new Piloto
                {
                    Id = 8,
                    Nombre = "Dave Seth",
                    Numero = "11",
                    FotoPiloto = "",
                    CarrerasGanadas = 7,
                    Poles = 10,
                    Top5s = 16,
                    Top10s = 28,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 31
                },
                new Piloto
                {
                    Id = 9,
                    Nombre = "Roger Moore",
                    Numero = "12",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 1,
                    Top5s = 2,
                    Top10s = 5,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 3,
                    Edad = 24
                },
                new Piloto
                {
                    Id = 10,
                    Nombre = "Philipp Harrinson",
                    Numero = "14",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 0,
                    Top10s = 3,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 23
                },
                new Piloto
                {
                    Id = 11,
                    Nombre = "Daniel Suarez",
                    Numero = "15",
                    FotoPiloto = "",
                    CarrerasGanadas = 27,
                    Poles = 17,
                    Top5s = 43,
                    Top10s = 60,
                    Campeonatos = 1,
                    EnActivo = true,
                    NacionalidadId = 4,
                    Edad = 38
                },
                new Piloto
                {
                    Id = 12,
                    Nombre = "Agustin Canapino",
                    Numero = "16",
                    FotoPiloto = "",
                    CarrerasGanadas = 3,
                    Poles = 7,
                    Top5s = 17,
                    Top10s = 33,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 5,
                    Edad = 39
                },
                new Piloto
                {
                    Id = 13,
                    Nombre = "Kenny Douglas",
                    Numero = "17",
                    FotoPiloto = "",
                    CarrerasGanadas = 1,
                    Poles = 2,
                    Top5s = 4,
                    Top10s = 10,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 26
                },
                new Piloto
                {
                    Id = 14,
                    Nombre = "Marnie Miller",
                    Numero = "18",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 0,
                    Top10s = 0,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 21
                },
                new Piloto
                {
                    Id = 15,
                    Nombre = "Matt McGlovin",
                    Numero = "21",
                    FotoPiloto = "",
                    CarrerasGanadas = 3,
                    Poles = 9,
                    Top5s = 10,
                    Top10s = 21,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 27
                },
                new Piloto
                {
                    Id = 16,
                    Nombre = "Pierre Lefevre",
                    Numero = "22",
                    FotoPiloto = "",
                    CarrerasGanadas = 5,
                    Poles = 3,
                    Top5s = 20,
                    Top10s = 39,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 6,
                    Edad = 33
                },
                new Piloto
                {
                    Id = 17,
                    Nombre = "Jack Miller",
                    Numero = "24",
                    FotoPiloto = "",
                    CarrerasGanadas = 97,
                    Poles = 53,
                    Top5s = 183,
                    Top10s = 270,
                    Campeonatos = 6,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 48
                },
                new Piloto
                {
                    Id = 18,
                    Nombre = "Emmet Wilson",
                    Numero = "27",
                    FotoPiloto = "",
                    CarrerasGanadas = 1,
                    Poles = 0,
                    Top5s = 6,
                    Top10s = 14,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 34
                },
                new Piloto
                {
                    Id = 19,
                    Nombre = "Michael Schmidt",
                    Numero = "29",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 9,
                    Top10s = 17,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 29
                },
                new Piloto
                {
                    Id = 20,
                    Nombre = "Colton Berta",
                    Numero = "31",
                    FotoPiloto = "",
                    CarrerasGanadas = 8,
                    Poles = 15,
                    Top5s = 21,
                    Top10s = 34,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 36
                },
                new Piloto
                {
                    Id = 21,
                    Nombre = "Thomas Turner",
                    Numero = "32",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 2,
                    Top10s = 6,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 32
                },
                new Piloto
                {
                    Id = 22,
                    Nombre = "Miles Biffle",
                    Numero = "34",
                    FotoPiloto = "",
                    CarrerasGanadas = 1,
                    Poles = 2,
                    Top5s = 9,
                    Top10s = 19,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 25
                },
                new Piloto
                {
                    Id = 23,
                    Nombre = "Mark Martins",
                    Numero = "36",
                    FotoPiloto = "",
                    CarrerasGanadas = 4,
                    Poles = 1,
                    Top5s = 28,
                    Top10s = 53,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 30
                },
                new Piloto
                {
                    Id = 24,
                    Nombre = "Noah Sanders",
                    Numero = "37",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 0,
                    Top10s = 8,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 24
                },
                new Piloto
                {
                    Id = 25,
                    Nombre = "Reginald Loundon",
                    Numero = "38",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 1,
                    Top10s = 3,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 3,
                    Edad = 25
                },
                new Piloto
                {
                    Id = 26,
                    Nombre = "Kevin Magnussen",
                    Numero = "39",
                    FotoPiloto = "",
                    CarrerasGanadas = 13,
                    Poles = 21,
                    Top5s = 31,
                    Top10s = 47,
                    Campeonatos = 3,
                    EnActivo = true,
                    NacionalidadId = 8,
                    Edad = 43
                },
                new Piloto
                {
                    Id = 27,
                    Nombre = "Scott Gilliham",
                    Numero = "42",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 1,
                    Top10s = 5,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 27
                },
                new Piloto
                {
                    Id = 28,
                    Nombre = "Oliver Cook",
                    Numero = "47",
                    FotoPiloto = "",
                    CarrerasGanadas = 1,
                    Poles = 0,
                    Top5s = 6,
                    Top10s = 12,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 34
                },
                new Piloto
                {
                    Id = 29,
                    Nombre = "Lewis Hammersmith",
                    Numero = "48",
                    FotoPiloto = "",
                    CarrerasGanadas = 21,
                    Poles = 40,
                    Top5s = 36,
                    Top10s = 56,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 3,
                    Edad = 30
                },
                new Piloto
                {
                    Id = 30,
                    Nombre = "Carl Menard",
                    Numero = "50",
                    FotoPiloto = "",
                    CarrerasGanadas = 6,
                    Poles = 8,
                    Top5s = 11,
                    Top10s = 26,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 36
                },
                new Piloto
                {
                    Id = 31,
                    Nombre = "Tony Montana",
                    Numero = "55",
                    FotoPiloto = "",
                    CarrerasGanadas = 1,
                    Poles = 2,
                    Top5s = 7,
                    Top10s = 22,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 29
                },
                new Piloto
                {
                    Id = 32,
                    Nombre = "Pipo Argenti",
                    Numero = "56",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 0,
                    Top10s = 1,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 7,
                    Edad = 24
                },
                new Piloto
                {
                    Id = 33,
                    Nombre = "Henry Brooks",
                    Numero = "71",
                    FotoPiloto = "",
                    CarrerasGanadas = 1,
                    Poles = 1,
                    Top5s = 2,
                    Top10s = 4,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 35
                },
                new Piloto
                {
                    Id = 34,
                    Nombre = "Chad Pepper",
                    Numero = "73",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 1,
                    Top5s = 4,
                    Top10s = 20,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 33
                },
                new Piloto
                {
                    Id = 35,
                    Nombre = "Santino Boscatto",
                    Numero = "77",
                    FotoPiloto = "",
                    CarrerasGanadas = 35,
                    Poles = 29,
                    Top5s = 59,
                    Top10s = 69,
                    Campeonatos = 3,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 31
                },
                new Piloto
                {
                    Id = 36,
                    Nombre = "Quinn Simons",
                    Numero = "81",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 2,
                    Top10s = 7,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 28
                },
                new Piloto
                {
                    Id = 37,
                    Nombre = "Marco Rossi",
                    Numero = "83",
                    FotoPiloto = "",
                    CarrerasGanadas = 4,
                    Poles = 6,
                    Top5s = 21,
                    Top10s = 40,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 7,
                    Edad = 36
                },
                new Piloto
                {
                    Id = 38,
                    Nombre = "Benjamin Owen",
                    Numero = "87",
                    FotoPiloto = "",
                    CarrerasGanadas = 0,
                    Poles = 0,
                    Top5s = 0,
                    Top10s = 3,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 26
                },
                new Piloto
                {
                    Id = 39,
                    Nombre = "Harry Mcqueen",
                    Numero = "88",
                    FotoPiloto = "",
                    CarrerasGanadas = 13,
                    Poles = 22,
                    Top5s = 30,
                    Top10s = 41,
                    Campeonatos = 0,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 29
                },
                new Piloto
                {
                    Id = 40,
                    Nombre = "Cole Anderson",
                    Numero = "99",
                    FotoPiloto = "",
                    CarrerasGanadas = 17,
                    Poles = 25,
                    Top5s = 29,
                    Top10s = 51,
                    Campeonatos = 1,
                    EnActivo = true,
                    NacionalidadId = 1,
                    Edad = 32
                }
            );
        }
        public static void CrearAutos(EntityTypeBuilder<Auto> builder)
        {
            builder.HasData
            (
                new Auto
                {
                    Id = 1,
                    PilotoId = 1,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 2,
                    PilotoId = 2,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 3,
                    PilotoId = 3,
                    Foto = "",
                    MarcaId = 3,
                },
                new Auto
                {
                    Id = 4,
                    PilotoId = 4,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 5,
                    PilotoId = 5,
                    Foto = "",
                    MarcaId = 3,
                },
                new Auto
                {
                    Id = 6,
                    PilotoId = 6,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 7,
                    PilotoId = 7,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 8,
                    PilotoId = 8,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 9,
                    PilotoId = 9,
                    Foto = "",
                    MarcaId = 3,
                },
                new Auto
                {
                    Id = 10,
                    PilotoId = 10,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 11,
                    PilotoId = 11,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 12,
                    PilotoId = 12,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 13,
                    PilotoId = 13,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 14,
                    PilotoId = 14,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 15,
                    PilotoId = 15,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 16,
                    PilotoId = 16,
                    Foto = "",
                    MarcaId = 3,
                },
                new Auto
                {
                    Id = 17,
                    PilotoId = 17,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 18,
                    PilotoId = 18,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 19,
                    PilotoId = 19,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 20,
                    PilotoId = 20,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 21,
                    PilotoId = 21,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 22,
                    PilotoId = 22,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 23,
                    PilotoId = 23,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 24,
                    PilotoId = 24,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 25,
                    PilotoId = 25,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 26,
                    PilotoId = 26,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 27,
                    PilotoId = 27,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 28,
                    PilotoId = 28,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 29,
                    PilotoId = 29,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 30,
                    PilotoId = 30,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 31,
                    PilotoId = 31,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 32,
                    PilotoId = 32,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 33,
                    PilotoId = 33,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 34,
                    PilotoId = 34,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 35,
                    PilotoId = 35,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 36,
                    PilotoId = 36,
                    Foto = "",
                    MarcaId = 2,
                },
                new Auto
                {
                    Id = 37,
                    PilotoId = 37,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 38,
                    PilotoId = 38,
                    Foto = "",
                    MarcaId = 4,
                },
                new Auto
                {
                    Id = 39,
                    PilotoId = 39,
                    Foto = "",
                    MarcaId = 1,
                },
                new Auto
                {
                    Id = 40,
                    PilotoId = 40,
                    Foto = "",
                    MarcaId = 2,
                }
            );
        }
        public static void CrearPista(EntityTypeBuilder<Pista> builder)
        {
            builder.HasData
            (
                new Pista
                {
                    Id = 1,
                    Nombre = "Daytona 500",
                    Distancia = "",
                    Vueltas = 200,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 1,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 2,
                    Nombre = "California 500",
                    Distancia = "",
                    Vueltas = 250,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 2,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 3,
                    Nombre = "California Night 600",
                    Distancia = "",
                    Vueltas = 275,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 3,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 4,
                    Nombre = "Darlington 500",
                    Distancia = "",
                    Vueltas = 367,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 4,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 5,
                    Nombre = "Gateway 400",
                    Distancia = "",
                    Vueltas = 267,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 5,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 6,
                    Nombre = "Martinsville 500",
                    Distancia = "",
                    Vueltas = 500,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 6,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 7,
                    Nombre = "Atlanta 500",
                    Distancia = "",
                    Vueltas = 325,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 7,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 8,
                    Nombre = "Atlanta Night 600",
                    Distancia = "",
                    Vueltas = 350,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 8,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 9,
                    Nombre = "Watkins Glen 220",
                    Distancia = "",
                    Vueltas = 90,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 9,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 10,
                    Nombre = "Dover 400",
                    Distancia = "",
                    Vueltas = 267,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 10,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 11,
                    Nombre = "Kansas 400",
                    Distancia = "",
                    Vueltas = 267,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 11,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 12,
                    Nombre = "Las Vegas 400",
                    Distancia = "",
                    Vueltas = 267,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 12,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 13,
                    Nombre = "Twin Ring 400",
                    Distancia = "",
                    Vueltas = 250,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 13,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 14,
                    Nombre = "Bristol Dirty Night 500",
                    Distancia = "",
                    Vueltas = 500,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 14,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 15,
                    Nombre = "Indianapolis 400",
                    Distancia = "",
                    Vueltas = 160,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 15,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 16,
                    Nombre = "Nashville 400",
                    Distancia = "",
                    Vueltas = 325,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 16,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 17,
                    Nombre = "Nazareth 400",
                    Distancia = "",
                    Vueltas = 325,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 17,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 18,
                    Nombre = "Infineon 350k",
                    Distancia = "",
                    Vueltas = 112,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 18,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 19,
                    Nombre = "Rockingham 350",
                    Distancia = "",
                    Vueltas = 393,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 19,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 20,
                    Nombre = "Phoenix 500k",
                    Distancia = "",
                    Vueltas = 312,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 20,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 21,
                    Nombre = "New Hampshire 400",
                    Distancia = "",
                    Vueltas = 312,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 21,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 22,
                    Nombre = "Pocono 500",
                    Distancia = "",
                    Vueltas = 200,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 22,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 23,
                    Nombre = "Richmond 400",
                    Distancia = "",
                    Vueltas = 400,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 23,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 24,
                    Nombre = "Evergreen 400",
                    Distancia = "",
                    Vueltas = 450,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 24,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 25,
                    Nombre = "Talladega 500",
                    Distancia = "",
                    Vueltas = 188,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 25,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 26,
                    Nombre = "Milwaukee Night 450",
                    Distancia = "",
                    Vueltas = 350,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 26,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 27,
                    Nombre = "Chicagoland 400",
                    Distancia = "",
                    Vueltas = 267,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 27,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 28,
                    Nombre = "Iowa Night 400",
                    Distancia = "",
                    Vueltas = 400,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 28,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 29,
                    Nombre = "Kentucky Speedway 400",
                    Distancia = "",
                    Vueltas = 267,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 29,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 30,
                    Nombre = "Michigan 400",
                    Distancia = "",
                    Vueltas = 200,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 30,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 31,
                    Nombre = "Lowes Night 600",
                    Distancia = "",
                    Vueltas = 400,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 31,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 32,
                    Nombre = "Bristol 500",
                    Distancia = "",
                    Vueltas = 500,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 32,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 33,
                    Nombre = "Bristol Night 500",
                    Distancia = "",
                    Vueltas = 500,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 33,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 34,
                    Nombre = "Texas 500",
                    Distancia = "",
                    Vueltas = 333,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 34,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 35,
                    Nombre = "Coca Cola 600",
                    Distancia = "",
                    Vueltas = 250,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 35,
                    Disputada = false,
                    EnElCalendario = true,
                },
                new Pista
                {
                    Id = 36,
                    Nombre = "Homestead Miami 400 Championship",
                    Distancia = "",
                    Vueltas = 267,
                    FotoPrimaria = "",
                    FotoSecundaria = "",
                    FotoTerciaria = "",
                    Orden = 36,
                    Disputada = false,
                    EnElCalendario = true,
                }
            );
        }
    }
}
