using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Autor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAutorById
{
    public class GetAutorByIdQueryHandler : IRequestHandler<GetAutorByIdQuery, GetAutorByIdResponseDTO?>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;
        public GetAutorByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<GetAutorByIdResponseDTO?> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await context.Autors.ProjectTo<GetAutorByIdResponseDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (response is null) return null;
            return response;
        }
    }
}
