
using AutoMapper;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.CreateLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.UpdateLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetAllLibros;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByAutorLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByIdLibro;
using PruebaMicroservicios.Libro.Domain.Entities;

namespace PruebaMicroservicios.Libro.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibroEntity, GetAllLibrosResponseDTO>().ReverseMap();
            CreateMap<LibroEntity, GetByIdLibroResposeDTO?>().ReverseMap();
            CreateMap<LibroEntity, GetByAutorLibroResponseDTO?>().ReverseMap();

            CreateMap<CreateLibroCommand, LibroEntity>();
            CreateMap<UpdateLibroCommand, LibroEntity>(); 
        }
    }
}
