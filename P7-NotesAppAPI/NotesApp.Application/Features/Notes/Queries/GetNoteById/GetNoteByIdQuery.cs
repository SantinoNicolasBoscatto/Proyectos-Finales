using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQuery : IRequest<Note>
    {
        public string? IdentityUserId { get; set; }
        public int NoteId { get; set; }
    }
}
