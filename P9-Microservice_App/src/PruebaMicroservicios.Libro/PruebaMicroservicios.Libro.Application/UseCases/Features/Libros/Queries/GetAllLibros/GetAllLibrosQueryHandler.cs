using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Libro.Application.Interfaces;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetAllLibros
{
    public class GetAllLibrosQueryHandler : IRequestHandler<GetAllLibrosQuery, List<GetAllLibrosResponseDTO>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetAllLibrosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GetAllLibrosResponseDTO>> Handle(GetAllLibrosQuery request, CancellationToken cancellationToken)
        {
            return await context.Libros.ProjectTo<GetAllLibrosResponseDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
