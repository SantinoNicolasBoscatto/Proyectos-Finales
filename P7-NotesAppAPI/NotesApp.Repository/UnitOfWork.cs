using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Contracts.Repositories;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Data;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContextNotes Context { get; set; }
        private readonly DbContextNotes _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(DbContextNotes dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this._mapper = mapper;
            this.Context = _dbContext;
        }

        private INoteRepository? _noteRepository;
        public INoteRepository NoteRepository => _noteRepository ??= new NoteRepository(_dbContext, _mapper);

        private IToDoTaskRepository? _toDoTaskRepository;
        public IToDoTaskRepository ToDoTaskRepository => _toDoTaskRepository ??= new ToDoTaskRepository(_dbContext, _mapper);

        private ICategoryRepository? _categoryRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext, _mapper);

        private IPriorityRepository? _priorityRepository;
        public IPriorityRepository PriorityRepository => _priorityRepository ??= new PriorityRepository(_dbContext, _mapper);

        private IStatusRepository? _statusRepository;
        public IStatusRepository StatusRepository => _statusRepository ??= new StatusRepository(_dbContext, _mapper);

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
