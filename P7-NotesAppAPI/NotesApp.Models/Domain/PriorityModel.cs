using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Models.Domain
{
    public class PriorityModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<ToDoTaskModel> ToDoTasks { get; set; } = new List<ToDoTaskModel>();
    }
}
