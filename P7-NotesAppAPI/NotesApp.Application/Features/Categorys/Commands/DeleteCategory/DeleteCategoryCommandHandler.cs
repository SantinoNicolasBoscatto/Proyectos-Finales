using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Categorys.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CategoryRepository.DeleteEntity(request.Id);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new GenericException("Error al borrar el record");
            return Unit.Value;
        }
    }
}
