using AutoMapper;
using MediatR;
using PruebaMicroservicios.Autor.Application.Interfaces;
using PruebaMicroservicios.Autor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.CreateAutor
{
    public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, bool>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        public CreateAutorCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var autor = mapper.Map<AutorEntity>(request);
                await context.Autors.AddAsync(autor);
                var result = await context.SaveChangesAsync();
                if (result > 0) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
