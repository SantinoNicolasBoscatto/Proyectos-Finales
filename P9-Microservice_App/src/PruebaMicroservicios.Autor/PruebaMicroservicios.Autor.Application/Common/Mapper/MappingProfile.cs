using AutoMapper;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.CreateAutor;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.UpdateAutor;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAllAutors;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAutorById;
using PruebaMicroservicios.Autor.Domain.Entities;

namespace PruebaMicroservicios.Autor.Application.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorEntity, GetAllAutorsResponseDTO>().ReverseMap();
            CreateMap<AutorEntity, GetAutorByIdResponseDTO>().ReverseMap();

            CreateMap<CreateAutorCommand, AutorEntity>();
            CreateMap<UpdateAutorCommand, AutorEntity>();
        }
    }
}
