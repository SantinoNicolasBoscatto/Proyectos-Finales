using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NascarPage.Entitys.Configs
{
    public class AutoConfig : IEntityTypeConfiguration<Auto>
    {
        public void Configure(EntityTypeBuilder<Auto> builder)
        {
            builder.HasOne(x => x.Marca)
            .WithMany(x => x.ListaAutos)
            .HasForeignKey(x => x.MarcaId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
