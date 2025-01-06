using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Priorities.Queries
{
    public class GetPrioritiesQueryHandler : IRequestHandler<GetPrioritiesQuery, List<Priority>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPrioritiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Priority>> Handle(GetPrioritiesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.PriorityRepository.GetAll();
            return list.ToList();
        }
    }
}
