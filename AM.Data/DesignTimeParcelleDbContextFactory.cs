using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AM.Data
{
    public class DesignTimeParcelleDbContextFactory : IDesignTimeDbContextFactory<ParcelleDbContext>
    {
        public ParcelleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ParcelleDbContext>();

            // Change this if you're using a different DB
            optionsBuilder.UseSqlServer("Server=localhost;Database=test_db_dotnet;Trusted_Connection=True;TrustServerCertificate=True");

            return new ParcelleDbContext(optionsBuilder.Options);
        }
    }
}
