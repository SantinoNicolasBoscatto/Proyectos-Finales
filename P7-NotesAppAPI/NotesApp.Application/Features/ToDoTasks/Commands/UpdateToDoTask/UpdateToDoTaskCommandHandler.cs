using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask
{
    public class UpdateToDoTaskCommandHandler : IRequestHandler<UpdateToDoTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateToDoTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ToDoTaskRepository.GetPerUserNoteById(request.IdentityUserId, request.NoteId, request.ToDoTaskId);
            if (entity == null) throw new GenericException("El elemento a actualizar no existe o no tiene acceso a el");

            var toDo = new ToDoTask
            {
                Id = request.ToDoTaskId,
                DateLimit = request.DateLimit,
                Name = request.Name,
                NoteId = request.NoteId,
                PriorityId = request.PriorityId,
                StatusId = request.StatusId,
            };
            await _unitOfWork.ToDoTaskRepository.UpdateEntity(toDo);
            var result = await _unitOfWork.Complete();
            _unitOfWork.Dispose();
            if (result <= 0) throw new Exception("Error al actualizar Record");
            return Unit.Value;
        }
    }
}
