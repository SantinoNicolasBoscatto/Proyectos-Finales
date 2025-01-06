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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContextNotes dbContext;
        private readonly IMapper mapper;
        public CategoryRepository(DbContextNotes dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateEntity(Category entity)
        {
            var model = mapper.Map<CategoryModel>(entity);
            await dbContext.Categories.AddAsync(model);
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await dbContext.Categories.FindAsync(id);
            if (entity == null) return;
            dbContext.Remove(entity!);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var list = await dbContext.Categories.ToListAsync();
            var model = mapper.Map<List<Category>>(list);
            return model;
        }

        public Task UpdateEntity(Category entity)
        {
            var model = mapper.Map<CategoryModel>(entity);
            dbContext.Categories.Update(model);
            return Task.CompletedTask;
        }
    }
}
