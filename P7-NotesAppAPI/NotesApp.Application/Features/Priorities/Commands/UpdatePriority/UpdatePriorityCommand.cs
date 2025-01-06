using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Priorities.Commands.UpdatePriority
{
    public class UpdatePriorityCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
