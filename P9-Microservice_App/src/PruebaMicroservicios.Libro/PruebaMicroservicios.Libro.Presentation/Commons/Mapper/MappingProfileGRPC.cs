using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.CreateLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.UpdateLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetAllLibros;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByAutorLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByIdLibro;

namespace PruebaMicroservicios.Libro.Presentation.Commons.Mapper
{
    public class MappingProfileGRPC : Profile
    {
        public MappingProfileGRPC()
        {
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<GetAllLibrosResponseDTO, LibroResponse>();
            CreateMap<GetByIdLibroResposeDTO, LibroResponse>();
            CreateMap<GetByAutorLibroResponseDTO, LibroResponse>();


            CreateMap<CreateLibroRequest, CreateLibroCommand>();
            CreateMap<UpdateLibroRequest, UpdateLibroCommand>();
        }
    }
}
