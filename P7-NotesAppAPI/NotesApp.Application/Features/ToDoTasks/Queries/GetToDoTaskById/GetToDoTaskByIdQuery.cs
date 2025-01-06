using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Queries.GetToDoTaskById
{
    public class GetToDoTaskByIdQuery : IRequest<ToDoTask>
    {
        public string IdentityUserId { get; set; } = null!;
        public int Id { get; set; }
    }
}
