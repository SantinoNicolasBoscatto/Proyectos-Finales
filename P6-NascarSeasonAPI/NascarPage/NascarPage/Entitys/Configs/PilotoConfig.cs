using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace NascarPage.Entitys.Configs
{
    public class PilotoConfig : IEntityTypeConfiguration<Piloto>
    {
        public void Configure(EntityTypeBuilder<Piloto> builder)
        {
            builder.HasOne(p => p.Auto)
            .WithOne(a => a.Piloto)
            .HasForeignKey<Auto>(a => a.PilotoId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Nacionalidad)
            .WithMany(n => n.ListaPilotos)
            .HasForeignKey(p => p.NacionalidadId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
