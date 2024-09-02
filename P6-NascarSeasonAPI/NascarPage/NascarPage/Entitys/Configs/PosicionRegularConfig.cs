using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace NascarPage.Entitys.Configs
{
    public class PosicionRegularConfig : IEntityTypeConfiguration<PosicionCampeonatoRegular>
    {
        public void Configure(EntityTypeBuilder<PosicionCampeonatoRegular> builder)
        {
            builder.HasOne(pc => pc.Playoff)
           .WithOne(po => po.Regular)
           .HasForeignKey<PosicionPlayoff>(po => po.Id)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
