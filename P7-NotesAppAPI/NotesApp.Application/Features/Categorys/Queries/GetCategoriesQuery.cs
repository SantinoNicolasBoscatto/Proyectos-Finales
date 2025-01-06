using MediatR;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.Categorys.Queries
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {
    }
}
