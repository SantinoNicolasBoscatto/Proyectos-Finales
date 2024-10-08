using Microsoft.EntityFrameworkCore;
using ServiManagement.Models.Entidades;
using System.Reflection;

namespace ServiManagement.Models._Negocio
{
    public class Negocio : DbContext
    {
        public Negocio(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
    }
}
