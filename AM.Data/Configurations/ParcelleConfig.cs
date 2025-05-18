using AM.Core.Domaine;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AM.Data.Configurations
{
    public class ParcelleConfig : IEntityTypeConfiguration<Parcelle>
    {
        public void Configure(EntityTypeBuilder<Parcelle> builder)
        {
            builder.HasKey(p => p.Reference);

            builder.Property(p => p.Reference)
                   .HasMaxLength(10);
        }
    }
}
