using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NoteRepository.GetByIdPerUser(request.IdentityUserId, request.Id);
            if (entity == null) throw new GenericException("La Nota a modificar no se encuentra o no tiene acceso para modificarla");

            var note = new Note
            {
                Id = entity.Id,
                Name = request.Name,
                IdentityUserId = request.IdentityUserId,
                CategoryId = request.CategoryId
            };
            await _unitOfWork.NoteRepository.UpdateEntity(note);
            var result = await _unitOfWork.Complete();
            _unitOfWork.Dispose();
            if (result <= 0) throw new Exception("Error al insertar Record");
            return Unit.Value;
        }
    }
}
