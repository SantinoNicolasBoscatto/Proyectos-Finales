using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Priorities.Commands.UpdatePriority
{
    public class UpdatePriorityCommandHandler : IRequestHandler<UpdatePriorityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePriorityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Priority() { Id = request.Id, Name = request.Name };
            await _unitOfWork.PriorityRepository.UpdateEntity(entity);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new GenericException("Error, no se pudo modificar el registro");
            return Unit.Value;
        }
    }
}
