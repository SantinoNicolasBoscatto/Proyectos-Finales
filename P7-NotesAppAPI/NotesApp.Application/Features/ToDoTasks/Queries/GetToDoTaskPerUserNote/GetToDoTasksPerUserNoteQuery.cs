using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Queries.GetToDoTaskPerUserNote
{
    public class GetToDoTasksPerUserNoteQuery : IRequest<List<ToDoTask>>
    {
        public string IdentityUserId { get; set; } = null!;
        public int NoteId { get; set; }
        public bool Asc { get; set; }
        public bool Status { get; set; }
        public bool Priority { get; set; }
    }
}
