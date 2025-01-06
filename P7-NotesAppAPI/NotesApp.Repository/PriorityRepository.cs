using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Contracts.Repositories;
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
    public class PriorityRepository : IPriorityRepository
    {
        private readonly DbContextNotes dbContext;
        private readonly IMapper mapper;
        public PriorityRepository(DbContextNotes dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateEntity(Priority entity)
        {
            var model = mapper.Map<PriorityModel>(entity);
            await dbContext.Priorities.AddAsync(model);
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await dbContext.Priorities.FindAsync(id);
            if (entity == null) return;
            dbContext.Remove(entity!);
        }

        public async Task<IEnumerable<Priority>> GetAll()
        {
            var list = await dbContext.Priorities.ToListAsync();
            var model = mapper.Map<List<Priority>>(list);
            return model;
        }

        public Task UpdateEntity(Priority entity)
        {
            var model = mapper.Map<PriorityModel>(entity);
            dbContext.Priorities.Update(model);
            return Task.CompletedTask;
        }
    }
}
