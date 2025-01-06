using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Queries.GetNotesPerUserFilterByCategory
{
    public class GetNotesPerUserFilterByCategoryNameQueryHandler : IRequestHandler<GetNotesPerUserFilterByCategoryNameQuery, List<Note>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetNotesPerUserFilterByCategoryNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Note>> Handle(GetNotesPerUserFilterByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.NoteRepository.GetPerNameCategoryNote(request.IdentityUserId!, request.Name!,request.CategoryId);
        }
    }
}
