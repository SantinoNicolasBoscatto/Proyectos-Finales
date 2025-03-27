using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Autor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.DeleteOrder
{
    public class DeleteAutorCommandHandler : IRequestHandler<DeleteAutorCommand, bool>
    {
        private readonly IApplicationDbContext context;
        public DeleteAutorCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await context.Autors.FirstOrDefaultAsync(x => x.Id == request.AutorId);
            if (autor is null) return false;

            context.Autors.Remove(autor);
            if (await context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}
