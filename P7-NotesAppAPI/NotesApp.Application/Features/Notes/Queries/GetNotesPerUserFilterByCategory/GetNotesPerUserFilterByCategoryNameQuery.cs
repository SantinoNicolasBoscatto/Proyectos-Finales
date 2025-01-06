using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Queries.GetNotesPerUserFilterByCategory
{
    public class GetNotesPerUserFilterByCategoryNameQuery : IRequest<List<Note>>
    {
        public string? IdentityUserId { get; set; }
        public int CategoryId { get; set; }
        public string? Name { get; set; }
    }
}
