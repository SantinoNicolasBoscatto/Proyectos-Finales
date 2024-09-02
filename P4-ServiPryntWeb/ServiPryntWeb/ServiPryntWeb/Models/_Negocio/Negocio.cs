using Microsoft.EntityFrameworkCore;
using ServiPryntWeb.Models.Entidades;

namespace ServiPryntWeb.Models._Negocio
{
    public class Negocio : DbContext
    {
        private readonly IConfiguration? _configuration;

        
        public Negocio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Negocio()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cadena = _configuration!.GetConnectionString("SqLite");
            optionsBuilder.UseSqlite(connectionString: cadena);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasKey(x => x.IdProducto);
            modelBuilder.Entity<Marcas>().HasKey(x => x.IdMarca);
            modelBuilder.Entity<Usuario>().HasKey(x => x.IdUsuario);
            modelBuilder.Entity<TypeProduct>().HasKey(x => x.TypeId);

            modelBuilder.Entity<Productos>().Property(p => p.IdProducto).ValueGeneratedOnAdd();
            modelBuilder.Entity<Marcas>().Property(p => p.IdMarca).ValueGeneratedOnAdd();
            modelBuilder.Entity<Usuario>().Property(p => p.IdUsuario).ValueGeneratedOnAdd();
            modelBuilder.Entity<TypeProduct>().Property(p => p.TypeId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Productos>().HasOne(x => x.Marca)
            .WithMany(y => y.ProductosCollection).HasForeignKey(z => z.IdMarca);

            modelBuilder.Entity<Productos>().HasOne(x => x.TypeProduct)
            .WithMany(y => y.ProductosTypeCollection).HasForeignKey(z => z.TypeId);
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TypeProduct>? TypesProducts { get; set; }
    }
}
