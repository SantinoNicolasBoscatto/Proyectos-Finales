using AutoMapper;
using MediatR;
using PruebaMicroservicios.Libro.Application.Interfaces;
using PruebaMicroservicios.Libro.Domain.Entities;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.CreateLibro
{
    public class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, bool>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public CreateLibroCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
        {
            var libro = mapper.Map<LibroEntity>(request);
            await context.Libros.AddAsync(libro);
            if (await context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}
