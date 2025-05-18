using Microsoft.EntityFrameworkCore;
using AM.Core.Domaine;
using AM.Data.Configurations;

namespace AM.Data
{
    public class ParcelleDbContext : DbContext
    {
        public ParcelleDbContext(DbContextOptions<ParcelleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agriculteur> Agriculteurs { get; set; }
        public DbSet<Cooperative> Cooperatives { get; set; }
        public DbSet<Parcelle> Parcelles { get; set; }
        public DbSet<Agriculture> Agricultures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgriculteurConfig());
            modelBuilder.ApplyConfiguration(new CooperativeConfig());
            modelBuilder.ApplyConfiguration(new ParcelleConfig());
            modelBuilder.ApplyConfiguration(new AgricultureConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
