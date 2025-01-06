using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = new Status() { Id = request.Id, Name = request.Name };
            await _unitOfWork.StatusRepository.UpdateEntity(entity);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new GenericException("Error, no se pudo modificar el registro");
            return Unit.Value;
        }
    }
}
