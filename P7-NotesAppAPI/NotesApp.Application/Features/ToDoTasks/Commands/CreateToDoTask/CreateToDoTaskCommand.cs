using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Commands.CreateToDoTask
{
    public class CreateToDoTaskCommand : IRequest
    {
        public string? IdentityUserId { get; set; }
        public int NoteId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? DateLimit { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
    }
}
