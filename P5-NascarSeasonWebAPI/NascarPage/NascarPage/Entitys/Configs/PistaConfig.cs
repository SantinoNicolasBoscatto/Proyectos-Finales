using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace NascarPage.Entitys.Configs
{
    public class PistaConfig : IEntityTypeConfiguration<Pista>
    {
        public void Configure(EntityTypeBuilder<Pista> builder)
        {
            builder.HasIndex(x => x.Orden).IsUnique();
        }
    }
}
