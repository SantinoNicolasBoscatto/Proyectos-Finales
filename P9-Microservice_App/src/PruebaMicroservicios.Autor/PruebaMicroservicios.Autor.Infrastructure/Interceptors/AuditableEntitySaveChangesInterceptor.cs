using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PruebaMicroservicios.Autor.Domain.Entities;

namespace PruebaMicroservicios.Autor.Infrastructure.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context!);
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            UpdateEntities(eventData.Context!);
            return base.SavedChanges(eventData, result);
        }

        private void UpdateEntities(DbContext context)
        {
            if (context is null) return;

            foreach (var entry in context.ChangeTracker.Entries<AutorEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "System";
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedBy = "System";
                    entry.Entity.ModifiedDate = DateTime.Now;
                }
            }
        }
    }
}
