using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NoteRepository.GetByIdPerUser(request.IdentityUserId!, request.NoteId);
            if (entity == null) throw new GenericException("La Nota a eliminar no se encuentra o no tiene acceso para eliminarla");
            await _unitOfWork.NoteRepository.DeleteEntity(entity.Id);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new Exception("Error al borrar Record");
            return Unit.Value;
        }
    }
}
