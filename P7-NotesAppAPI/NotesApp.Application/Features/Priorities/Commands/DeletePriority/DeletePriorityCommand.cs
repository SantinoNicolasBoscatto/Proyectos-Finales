using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Priorities.Commands.DeletePriority
{
    public class DeletePriorityCommand : IRequest
    {
        public int Id { get; set; }
    }
}
