using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Statuses.Queries
{
    public class GetStatusQuery : IRequest<List<Status>>
    {}
}
