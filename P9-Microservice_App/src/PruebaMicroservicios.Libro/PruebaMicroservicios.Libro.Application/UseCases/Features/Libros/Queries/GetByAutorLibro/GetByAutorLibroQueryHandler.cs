using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Libro.Application.Interfaces;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByIdLibro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByAutorLibro
{
    public class GetByAutorLibroQueryHandler : IRequestHandler<GetByAutorLibroQuery, List<GetByAutorLibroResponseDTO>?>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        public GetByAutorLibroQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GetByAutorLibroResponseDTO>?> Handle(GetByAutorLibroQuery request, CancellationToken cancellationToken)
        {
            var listLibros = await context.Libros.ProjectTo<GetByAutorLibroResponseDTO>(mapper.ConfigurationProvider)
                .Where(x => x.AutorId == request.AutorId).ToListAsync();
            if (listLibros == null || listLibros.Count == 0) return null;

            return listLibros;
        }
    }
}
