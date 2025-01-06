using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NotesApp.Application.Contracts.Repositories;
using NotesApp.Data;
using NotesApp.Domain;
using NotesApp.Mapper.ManualMapper;
using NotesApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly DbContextNotes _dbContext;
        private readonly IMapper _mapper;
        public NoteRepository(DbContextNotes dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<Note> GetByIdPerUser(string userId, int noteId)
        {
            var model = await _dbContext.Notes.Include(x => x.Category).Include(x => x.ToDoTasks).AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdentityUserId == userId && x.Id == noteId);
            return _mapper.Map<Note>(model);
        }

        public async Task<List<Note>> GetPerUser(string userId)
        {
            List<NoteModel> model = await _dbContext.Notes.Include(x => x.Category)
                .Include(x => x.ToDoTasks)!.ThenInclude(x => x.Priority)
                .Include(x => x.ToDoTasks)!.ThenInclude(x => x.Status)
                .Where(x => x.IdentityUserId == userId).AsNoTracking().ToListAsync();
            return _mapper.Map<List<Note>>(model);
        }

        

        public async Task CreateEntity(Note entity)
        {
            var model = _mapper.Map<NoteModel>(entity);
            await _dbContext.Notes.AddAsync(model);
        }

        public Task UpdateEntity(Note entity)
        {
            var model = _mapper.Map<NoteModel>(entity);
            _dbContext.Notes.Update(model);
            return Task.CompletedTask;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _dbContext.Notes.FindAsync(id);
            _dbContext.Remove(entity!);
        }

        public async Task<List<Note>> GetPerNameCategoryNote(string userId, string name, int categoryId)
        {
            var query = _dbContext.Notes
                .Where(x => x.IdentityUserId == userId).AsQueryable();
            if (categoryId != 0)
            {
                if (!name.IsNullOrEmpty()) query = _dbContext.Notes.Where(x => x.Name.ToLower().Contains(name.ToLower()!) && x.Category.Id == categoryId && x.IdentityUserId == userId);
                else query = _dbContext.Notes.Where(x => x.IdentityUserId == userId && x.Category.Id == categoryId);
            }
            else if (!name.IsNullOrEmpty()) query = _dbContext.Notes.Where(x => x.Name.ToLower().Contains(name.ToLower()!) && x.IdentityUserId == userId);
            var list = await query.Include(x => x.Category)
                .Include(x => x.ToDoTasks)!.ThenInclude(x => x.Priority)
                .Include(x => x.ToDoTasks)!.ThenInclude(x => x.Status).ToListAsync();
            return _mapper.Map<List<Note>>(list);
        }


    }
}
