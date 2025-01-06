using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Contracts.Repositories;
using NotesApp.Application.Excepciones;
using NotesApp.Data;
using NotesApp.Domain;
using NotesApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Repository
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly DbContextNotes _dbContext;
        private readonly IMapper _mapper;
        public ToDoTaskRepository(DbContextNotes dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateEntity(ToDoTask entity)
        {
            var model = _mapper.Map<ToDoTaskModel>(entity);
            await _dbContext.ToDoTasks.AddAsync(model);
        }
        public Task UpdateEntity(ToDoTask entity)
        {
            var model = _mapper.Map<ToDoTaskModel>(entity);
            _dbContext.ToDoTasks.Update(model);
            return Task.CompletedTask;
        }
        public async Task DeleteEntity(int id)
        {
            var entity = await _dbContext.ToDoTasks.FindAsync(id);
            _dbContext.Remove(entity!);
        }

        public async Task<List<ToDoTask>> GetPerUserNote(string userId, int noteId, bool orderByStatus = false, bool orderByPriority = false, bool asc = true)
        {
            var query = _dbContext.ToDoTasks.Include(x => x.Priority).Include(x => x.Status)
                .Where(x => x.NoteId == noteId && x.Note.IdentityUserId == userId).AsQueryable();
            if(asc)
            {
                if(orderByStatus) query = query.OrderBy(x => x.Status.Id);
                if(orderByPriority) query = query.OrderBy(x => x.Priority.Id);
            }
            else
            {
                if (orderByStatus) query = query.OrderByDescending(x => x.Status.Id);
                if (orderByPriority) query = query.OrderByDescending(x => x.Priority.Id);
            }
            var list = await query.ToListAsync();
            var listFormateada = _mapper.Map<List<ToDoTask>>(list);
            return listFormateada;
        }

        public async Task<ToDoTask> GetPerUserNoteById(string userId, int noteId,int toDoTaskId)
        {
            var toDo = await _dbContext.ToDoTasks.AsNoTracking().Include(x => x.Priority).Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.Note.Id == noteId && x.Note.IdentityUserId == userId && x.Id == toDoTaskId);
            if (toDo == null) throw new GenericException("No se encuentra el ToDo");
            return _mapper.Map<ToDoTask>(toDo);
        }

        public async Task<ToDoTask> GetPerUserToDoById(string userId, int toDoTaskId)
        {
            var toDo = await _dbContext.ToDoTasks.AsNoTracking().Include(x => x.Priority).Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.Note.IdentityUserId == userId && x.Id == toDoTaskId);
            if (toDo == null) throw new GenericException("No se encuentra el ToDo");
            var toDoTask = _mapper.Map<ToDoTask>(toDo);
            return toDoTask;
        }
    }
}
