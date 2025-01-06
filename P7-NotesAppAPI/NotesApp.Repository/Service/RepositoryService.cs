using Microsoft.Extensions.DependencyInjection;
using NotesApp.Application.Contracts.Repositories;
using NotesApp.Application.Contracts.Security;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Repository.Service
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<ISecurityTokenConstructor, SecurityTokenConstructor>();
            return services;
        }
    }
}
