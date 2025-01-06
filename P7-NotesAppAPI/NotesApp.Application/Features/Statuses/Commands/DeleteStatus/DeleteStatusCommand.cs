using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommand : IRequest
    {
        public int Id { get; set; }
    }
}
