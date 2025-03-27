using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Libro.Application.Interfaces;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByIdLibro
{
    public class GetByIdLibroQueryHandler : IRequestHandler<GetByIdLibroQuery, GetByIdLibroResposeDTO?>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        public GetByIdLibroQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GetByIdLibroResposeDTO?> Handle(GetByIdLibroQuery request, CancellationToken cancellationToken)
        {
            var libro = await context.Libros.ProjectTo<GetByIdLibroResposeDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (libro == null) return null;
            return libro;
        }
    }
}
