using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;
using System.Reflection;

namespace NascarPage
{
    public class Negocio : DbContext
    {
        public Negocio(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Pista> Pistas { get; set; }
        public DbSet<Campeon> Campeones { get; set; }
        public DbSet<PosicionManofactura> TablaPosicionesManofactura { get; set; }
        public DbSet<PosicionCampeonatoRegular> TablaPosicionesCampeonatoRegular { get; set; }
        public DbSet<PosicionPlayoff> TablaPosicionesPlayoff { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Calendario> Calendario { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Galeria> Galeria { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
    }
}
