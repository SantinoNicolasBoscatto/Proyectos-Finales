using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {}
}
