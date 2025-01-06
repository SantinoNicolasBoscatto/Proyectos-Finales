using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Models.Domain
{
    public class ToDoTaskModel
    {
        public int Id { get; set; }
        public int NoteId { get; set; }

        public string? Name { get; set; }
        public DateTime? DateLimit { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }

        public PriorityModel Priority { get; set; } = null!;
        public StatusModel Status { get; set; } = null!;
        public NoteModel Note { get; set; } = null!;
    }
}
