using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.Repositories
{
    public interface IRepository<T>
    {
        Task CreateEntity(T entity);
        Task UpdateEntity(T entity);
        Task DeleteEntity(int id);
    }
}
