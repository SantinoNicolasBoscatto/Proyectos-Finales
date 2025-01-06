
namespace NotesApp.Models.Domain
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public string? Description { get; set; }
        public string IdentityUserId { get; set; } = null!;
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; } = null!;
        public List<ToDoTaskModel>? ToDoTasks { get; set; }
    }
}
