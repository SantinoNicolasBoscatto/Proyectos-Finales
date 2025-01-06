using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Name = request.Name,
                IdentityUserId = request.IdentityUserId!,
                CategoryId = request.CategoryId
            };
            await _unitOfWork.NoteRepository.CreateEntity(note);
            var result = await _unitOfWork.Complete();
            _unitOfWork.Dispose();
            if (result <= 0) throw new Exception("Error al insertar Record");
            return Unit.Value;
        }
    }
}
