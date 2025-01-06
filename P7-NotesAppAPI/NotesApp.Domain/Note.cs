
namespace NotesApp.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string IdentityUserId { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public List<ToDoTask>? ToDoTasks { get; set; }
    }
}
