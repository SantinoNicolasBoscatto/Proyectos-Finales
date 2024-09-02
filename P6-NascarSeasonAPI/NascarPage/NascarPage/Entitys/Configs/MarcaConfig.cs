using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace NascarPage.Entitys.Configs
{
    public class MarcaConfig : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.Property(x => x.Nombre)
            .HasMaxLength(50);

            builder.HasOne(x => x.PosicionManofactura)
            .WithOne(x => x.Marca)
            .HasForeignKey<PosicionManofactura>(x => x.MarcaId);
        }
    }
}
