using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Autor.Domain.Entities;

namespace PruebaMicroservicios.Autor.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<AutorEntity> Autors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
