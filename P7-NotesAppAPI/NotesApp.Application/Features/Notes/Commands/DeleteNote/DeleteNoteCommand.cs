using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public string? IdentityUserId { get; set; }
        public int NoteId { get; set; }
    }
}
