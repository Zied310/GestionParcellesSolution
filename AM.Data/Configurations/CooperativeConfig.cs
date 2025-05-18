using AM.Core.Domaine;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AM.Data.Configurations
{
    public class CooperativeConfig : IEntityTypeConfiguration<Cooperative>
    {
        public void Configure(EntityTypeBuilder<Cooperative> builder)
        {
            builder.HasKey(c => c.Reference); // Assuming primary key is Id
        }
    }
}
