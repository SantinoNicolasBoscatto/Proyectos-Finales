using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? IdentityUserId { get; set; }
    }
}
