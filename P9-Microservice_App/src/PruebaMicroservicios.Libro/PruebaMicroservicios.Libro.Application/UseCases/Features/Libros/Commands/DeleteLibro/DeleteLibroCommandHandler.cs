using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Libro.Application.Interfaces;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.DeleteLibro
{
    public class DeleteLibroCommandHandler : IRequestHandler<DeleteLibroCommand, bool>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        public DeleteLibroCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLibroCommand request, CancellationToken cancellationToken)
        {
            var libro = await context.Libros.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (libro is null) return false;

            context.Libros.Remove(libro);
            if (await context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}
