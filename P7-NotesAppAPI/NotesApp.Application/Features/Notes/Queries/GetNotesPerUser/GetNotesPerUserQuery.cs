using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Queries.GetNotesPerUser
{
    public class GetNotesPerUserQuery : IRequest<List<Note>>
    {
        public string? IdentityUserId { get; set; }
    }
}
