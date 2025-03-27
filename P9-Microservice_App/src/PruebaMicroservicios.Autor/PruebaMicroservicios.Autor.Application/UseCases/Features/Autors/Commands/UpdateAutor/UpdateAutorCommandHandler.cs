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

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.UpdateAutor
{
    public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;
        public UpdateAutorCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await context.Autors.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (autor is null) return false;

            autor = mapper.Map(request, autor);
            if (await context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}
