using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Priorities.Commands.CreatePriority
{
    public class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePriorityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Priority { Name = request.Name };
            await _unitOfWork.PriorityRepository.CreateEntity(entity);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new GenericException("Error, no se pudo crear el registro");
            return Unit.Value;
        }
    }
}
