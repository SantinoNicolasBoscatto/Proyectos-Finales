using NotesApp.Application.Contracts.Repositories;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public INoteRepository NoteRepository { get; }
        public IToDoTaskRepository ToDoTaskRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IStatusRepository StatusRepository { get; }
        public IPriorityRepository PriorityRepository { get; }

        Task<int> Complete();
    }
}
