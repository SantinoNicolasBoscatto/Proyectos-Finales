using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = new Status { Name = request.Name };
            await _unitOfWork.StatusRepository.CreateEntity(entity);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new GenericException("Error, no se pudo crear el registro");
            return Unit.Value;
        }
    }
}
