using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask
{
    public class DeleteToDoTaskCommandHandler : IRequestHandler<DeleteToDoTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteToDoTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ToDoTaskRepository.GetPerUserToDoById(request.IdentityUserId!,request.ToDoTaskId);
            if (entity == null) throw new GenericException("El elemento que quiere eliminar no existe o no tiene permisos");
            await _unitOfWork.ToDoTaskRepository.DeleteEntity(entity.Id);
            var result = await _unitOfWork.Complete();
            _unitOfWork.Dispose();
            if (result <= 0) throw new Exception("Error al borrar el ToDoTask");
            return Unit.Value;
        }
    }
}
