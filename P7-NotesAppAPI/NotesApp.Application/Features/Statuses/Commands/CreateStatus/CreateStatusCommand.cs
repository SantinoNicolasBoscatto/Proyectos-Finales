using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommand : IRequest
    {
        public string Name { get; set; } = null!;
    }
}
