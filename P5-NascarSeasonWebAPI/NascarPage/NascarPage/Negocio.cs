using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;
using NascarPage.Seeding;
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


            Seeding.Seeding.CrearNacionalidad(modelBuilder.Entity<Nacionalidad>());
            Seeding.Seeding.CrearMarcas(modelBuilder.Entity<Marca>());
            Seeding.Seeding.CrearPilotos(modelBuilder.Entity<Piloto>());
            Seeding.Seeding.CrearAutos(modelBuilder.Entity<Auto>());
            Seeding.Seeding.CrearPista(modelBuilder.Entity<Pista>());
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
    }
}
