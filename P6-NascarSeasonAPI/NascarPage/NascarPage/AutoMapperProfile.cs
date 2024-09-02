using AutoMapper;
using NascarPage.DTOs;
using NascarPage.Entitys;

namespace NascarPage
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // AUTO
            CreateMap<CrearAutoDTO, Auto>()
                .ForMember(dest => dest.Foto, opt => opt.Ignore());
            CreateMap<Auto, LecturaAutoDTO>();
            CreateMap<Auto, PatchAutoDTO>().ReverseMap();

            // PILOTO
            CreateMap<CrearPilotoDTO, Piloto>()
                .ForMember(dest => dest.FotoPiloto, opt => opt.Ignore());
            CreateMap<Piloto, LecturaPilotoDTO>();
            CreateMap<Piloto, PatchPilotoDTO>().ReverseMap();

            // MARCA
            CreateMap<CrearMarcaDTO, Marca>()
                .ForMember(dest => dest.Foto, opt => opt.Ignore());
            CreateMap<Marca, LecturaMarcaDTO>();

            // PISTA
            CreateMap<CrearPistaDTO, Pista>()
                .ForMember(dest => dest.FotoPrimaria, opt => opt.Ignore())
                .ForMember(dest => dest.FotoSecundaria, opt => opt.Ignore())
                .ForMember(dest => dest.FotoTerciaria, opt => opt.Ignore());
            CreateMap<Pista, LecturaPistaDTO>();
            CreateMap<Pista, PatchPistaDTO>().ReverseMap();


            //CAMPEON 
            CreateMap<CrearCampeonDTO, Campeon>()
               .ForMember(dest => dest.AutoCampeon, opt => opt.Ignore());
            CreateMap<Campeon, LecturaCampeonDTO>();
            CreateMap<Campeon, PatchCampeonDTO>().ReverseMap();


            //CARRERA
            CreateMap<CrearCarreraDTO, Carrera>()
               .ForMember(dest => dest.Finish, opt => opt.MapFrom(src => Convert.ToInt32(src.Finish)))
               .ForMember(dest => dest.Start, opt => opt.MapFrom(src => Convert.ToInt32(src.Start)))
               .ForMember(dest => dest.Laps, opt => opt.MapFrom(src => Convert.ToInt32(src.Laps)))
               .ForMember(dest => dest.Led, opt => opt.MapFrom(src => Convert.ToInt32(src.Led)))
               .ForMember(dest => dest.Puntos, opt => opt.MapFrom(src => Convert.ToInt32(src.Puntos)));

            CreateMap<Carrera, LecturaCarreraDTO>();

            CreateMap<PosicionCampeonatoRegular, LecturaRegularDTO>();
            CreateMap<PosicionPlayoff, LecturaPlayoffDTO>();
            CreateMap<PosicionManofactura, LecturaManofacturaDTO>();

            CreateMap<Piloto, PilotoRegularTablaDTO>();
            CreateMap<Marca, MarcaRegularTablaDTO>();

            // Nacionalidad
            CreateMap<CrearNacionalidadDTO, Nacionalidad>()
                .ForMember(dest => dest.Bandera, opt => opt.Ignore());
            CreateMap<Nacionalidad, LecturaNacionalidadDTO>();

            // GALERIA
            CreateMap<CrearGaleriaDTO, Galeria>()
               .ForMember(dest => dest.FotoUno, opt => opt.Ignore())
               .ForMember(dest => dest.FotoDos, opt => opt.Ignore())
               .ForMember(dest => dest.FotoTres, opt => opt.Ignore());
            CreateMap<Galeria, LecturaGaleriaDTO>();
        }
    }
}
