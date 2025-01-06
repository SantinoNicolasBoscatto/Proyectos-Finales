using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Statuses.Queries
{
    public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, List<Status>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetStatusQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Status>> Handle(GetStatusQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.StatusRepository.GetAll();
            return list.ToList();
        }
    }
}
