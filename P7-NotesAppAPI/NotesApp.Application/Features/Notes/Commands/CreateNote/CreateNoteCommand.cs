using MediatR;
namespace NotesApp.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? IdentityUserId { get; set; }
    }
}
