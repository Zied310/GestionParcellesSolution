using AM.Data;
using AM.Web.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

// Step 1: Create service collection
var services = new ServiceCollection();

// Step 2: Register DbContext
services.AddDbContext<ParcelleDbContext>(options =>
    options.UseMySql("server=localhost;database=test_db_dotnet;user=root;password=katana;",
        ServerVersion.AutoDetect("server=localhost;database=test_db_dotnet;user=root;password=katana;")
    )
);


// Step 3: Build service provider
var serviceProvider = services.BuildServiceProvider();

// Step 4: Create a scope and initialize the DB
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ParcelleDbContext>();

    // Optional: ensure database is deleted + created fresh each time
    // context.Database.EnsureDeleted();

    DbInitializer.Initialize(context);
    context.Database.EnsureCreated();
}

Console.WriteLine("Database initialized successfully!");
