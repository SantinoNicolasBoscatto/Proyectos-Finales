using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Contracts.Repositories;
using NotesApp.Application.Excepciones;
using NotesApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContextNotes dbContext;
        public GenericRepository(DbContextNotes dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll() => await dbContext.Set<T>().ToListAsync();
        public async Task CreateEntity(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
        }
        public Task UpdateEntity(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
        public async Task DeleteEntity(int id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);
            if (entity == null) return;
            dbContext.Remove(entity!);
        }     
    }
}
