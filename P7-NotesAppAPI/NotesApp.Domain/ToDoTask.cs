using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public int NoteId { get; set; }

        public string? Name { get; set; }
        public DateTime? DateLimit { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }

        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
        public Note? Note { get; set; }
    }
}
