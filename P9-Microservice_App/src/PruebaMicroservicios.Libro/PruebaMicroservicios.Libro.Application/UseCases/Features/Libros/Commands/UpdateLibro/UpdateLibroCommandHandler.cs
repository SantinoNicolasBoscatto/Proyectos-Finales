using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Libro.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.UpdateLibro
{
    public class UpdateLibroCommandHandler : IRequestHandler<UpdateLibroCommand, bool>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        public UpdateLibroCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateLibroCommand request, CancellationToken cancellationToken)
        {
            var libro = await context.Libros.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (libro is null) return false;

            libro = mapper.Map(request, libro);
            if (await context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}
