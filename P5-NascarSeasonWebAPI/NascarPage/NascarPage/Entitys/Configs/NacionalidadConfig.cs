using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NascarPage.Entitys.Configs
{
    public class NacionalidadConfig : IEntityTypeConfiguration<Nacionalidad>
    {
        public void Configure(EntityTypeBuilder<Nacionalidad> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(50);
        }
    }
}
