using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Queries.GetToDoTaskPerUserNote
{
    public class GetToDoTasksPerUserNoteQueryHandler : IRequestHandler<GetToDoTasksPerUserNoteQuery, List<ToDoTask>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetToDoTasksPerUserNoteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ToDoTask>> Handle(GetToDoTasksPerUserNoteQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ToDoTaskRepository.GetPerUserNote(request.IdentityUserId, request.NoteId, request.Status, request.Priority, request.Asc);
        }
    }
}
