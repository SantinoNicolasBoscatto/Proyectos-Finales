using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Queries.GetNotesPerUser
{
    public class GetNotesPerUserQueryHandler : IRequestHandler<GetNotesPerUserQuery, List<Note>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetNotesPerUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Note>> Handle(GetNotesPerUserQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.NoteRepository.GetPerUser(request.IdentityUserId!);
        }
    }
}
