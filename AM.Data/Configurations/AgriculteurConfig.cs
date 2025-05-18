using AM.Core.Domaine;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AM.Data.Configurations
{
    public class AgriculteurConfig : IEntityTypeConfiguration<Agriculteur>
    {
        public void Configure(EntityTypeBuilder<Agriculteur> builder)
        {
            builder.HasKey(a => a.CIN);
            builder.Property(a => a.Telephone)
                   .HasMaxLength(8);
        }
    }
}
