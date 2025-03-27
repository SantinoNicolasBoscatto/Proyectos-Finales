using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventBus.EventQueue;
using EventBus.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Autor.Application.Common.Validators;
using PruebaMicroservicios.Autor.Application.Interfaces;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAllAutors
{
    public class GetAllAutorsQueryHandler : IRequestHandler<GetAllAutorsQuery, List<GetAllAutorsResponseDTO>>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;
        private readonly IRabbitEventBus rabbitEventBus;
        public GetAllAutorsQueryHandler(IMapper mapper, IApplicationDbContext context, IRabbitEventBus rabbitEventBus)
        {
            this.mapper = mapper;
            this.context = context;
            this.rabbitEventBus = rabbitEventBus;
        }

        public async Task<List<GetAllAutorsResponseDTO>> Handle(GetAllAutorsQuery request, CancellationToken cancellationToken)
        {
            var autors = await context.Autors.ProjectTo<GetAllAutorsResponseDTO>(mapper.ConfigurationProvider).ToListAsync();
            if (autors == null) throw new ValidationExceptionCustom();

            await rabbitEventBus.Publish(new TestEventQueue("Hola soy un Mensaje, me comunico por un Broker"));
            return autors;
        }
    }
}
