using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.Repositories
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<List<Note>> GetPerUser(string userId);
        Task<Note> GetByIdPerUser(string userId, int noteId);
        Task<List<Note>> GetPerNameCategoryNote(string userId, string name, int categoryId);
    }
}
