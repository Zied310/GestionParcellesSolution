using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AM.Core.Domaine;

namespace AM.Data.Configurations
{
    public class AgricultureConfig : IEntityTypeConfiguration<Agriculture>
    {
        public void Configure(EntityTypeBuilder<Agriculture> builder)
        {
            // Composite primary key
            builder.HasKey(a => new { a.ParcelleRef, a.AgriculteurCIN });

            // Relationships
            builder.HasOne(a => a.Parcelle)
                   .WithMany(p => p.Agricultures)
                   .HasForeignKey(a => a.ParcelleRef);

            builder.HasOne(a => a.Agriculteur)
                   .WithMany(ag => ag.Agricultures)
                   .HasForeignKey(a => a.AgriculteurCIN);
        }
    }
}
