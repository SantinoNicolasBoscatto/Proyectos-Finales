using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiManagement.Models.Entidades.Configs
{
    public class OrdenesConfig : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.Property(x => x.NumeroDeOrden).HasMaxLength(25);
            builder.Property(x => x.Modelo).HasMaxLength(75);
            builder.HasOne(o => o.Usuario).WithMany(u => u.Ordenes).HasForeignKey(o => o.Tecnico);
        }
    }
}
