using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask
{
    public class DeleteToDoTaskCommand : IRequest
    {
        public string? IdentityUserId { get; set; }
        public int ToDoTaskId { get; set; }
    }
}
