using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Libro.Application.Interfaces;
using PruebaMicroservicios.Libro.Domain.Entities;
using PruebaMicroservicios.Libro.Infrastructure.Interceptors;

namespace PruebaMicroservicios.Libro.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<LibroEntity> Libros { get; set; }

        private readonly AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            this.auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibroEntity>().Property(x => x.Name).HasMaxLength(150);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
