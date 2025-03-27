using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Libro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Libro.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<LibroEntity> Libros { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
