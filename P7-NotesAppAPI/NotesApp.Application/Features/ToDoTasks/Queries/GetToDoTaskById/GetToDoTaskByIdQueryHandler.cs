using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Queries.GetToDoTaskById
{
    public class GetToDoTaskByIdQueryHandler : IRequestHandler<GetToDoTaskByIdQuery, ToDoTask>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetToDoTaskByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ToDoTask> Handle(GetToDoTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ToDoTaskRepository.GetPerUserToDoById(request.IdentityUserId, request.Id);
        }
    }
}
