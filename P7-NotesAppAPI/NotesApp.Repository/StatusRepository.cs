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
    public class StatusRepository : IStatusRepository
    {
        private readonly DbContextNotes dbContext;
        private readonly IMapper mapper;
        public StatusRepository(DbContextNotes dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateEntity(Status entity)
        {
            var model = mapper.Map<StatusModel>(entity);
            await dbContext.Status.AddAsync(model);
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await dbContext.Status.FindAsync(id);
            if (entity == null) return;
            dbContext.Remove(entity!);
        }

        public async Task<IEnumerable<Status>> GetAll()
        {
            var list = await dbContext.Status.ToListAsync();
            var model = mapper.Map<List<Status>>(list);
            return model;
        }

        public Task UpdateEntity(Status entity)
        {
            var model = mapper.Map<StatusModel>(entity);
            dbContext.Status.Update(model);
            return Task.CompletedTask;
        }
    }
}
