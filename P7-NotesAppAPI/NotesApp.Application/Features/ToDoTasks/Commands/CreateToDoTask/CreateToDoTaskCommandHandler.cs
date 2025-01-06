using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Commands.CreateToDoTask
{
    public class CreateToDoTaskCommandHandler : IRequestHandler<CreateToDoTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateToDoTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var note = await _unitOfWork.NoteRepository.GetByIdPerUser(request.IdentityUserId!, request.NoteId);
            if (note == null) throw new GenericException("Error al insertar Record");
            var toDo = new ToDoTask
            {
                DateLimit = request.DateLimit,
                Name = request.Name,
                NoteId = request.NoteId,
                PriorityId = request.PriorityId,
                StatusId = request.StatusId,
            };
            await _unitOfWork.ToDoTaskRepository.CreateEntity(toDo);
            var result = await _unitOfWork.Complete();
            _unitOfWork.Dispose();
            if (result <= 0) throw new GenericException("Error al insertar Record");
            return Unit.Value;
        }
    }
}
