using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Priorities.Commands.CreatePriority
{
    public class CreatePriorityCommand : IRequest
    {
        public string Name { get; set; } = null!;
    }
}
