using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, Note>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetNoteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Note> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.NoteRepository.GetByIdPerUser(request.IdentityUserId!, request.NoteId);
        }
    }
}
