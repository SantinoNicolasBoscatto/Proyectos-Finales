using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.CreateAutor;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.UpdateAutor;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAllAutors;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAutorById;

namespace PruebaMicroservicios.Autor.Presentation.Common.MappingProfile
{
    public class MappingProfileGRPC : Profile
    {
        public MappingProfileGRPC()
        {
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<GetAllAutorsResponseDTO, AutorResponse>();
            CreateMap<GetAutorByIdResponseDTO, AutorResponse>();


            CreateMap<CreateAutorRequest, CreateAutorCommand>();
            CreateMap<UpdateAutorRequest, UpdateAutorCommand>();
        }
    }
}
