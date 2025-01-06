using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.Repositories
{
    public interface IToDoTaskRepository : IRepository<ToDoTask>
    {
        Task<List<ToDoTask>> GetPerUserNote(string userId, int noteId, bool orderByStatus = false, bool orderByPriority = false, bool asc = true);
        Task<ToDoTask> GetPerUserNoteById(string userId, int noteId, int toDoTaskId);
        Task<ToDoTask> GetPerUserToDoById(string userId, int toDoTaskId);
    }
}
