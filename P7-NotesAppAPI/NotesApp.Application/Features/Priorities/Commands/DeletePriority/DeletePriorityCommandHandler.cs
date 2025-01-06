using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Priorities.Commands.DeletePriority
{
    public class DeletePriorityCommandHandler : IRequestHandler<DeletePriorityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePriorityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.PriorityRepository.DeleteEntity(request.Id);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new GenericException("Error al borrar el record");
            return Unit.Value;
        }
    }
}
