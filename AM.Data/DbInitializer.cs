using AM.Core.Domaine;
using AM.Data;

namespace AM.Web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ParcelleDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if data already exists
            if (context.Cooperatives.Any()) return;

            // Add cooperatives
            var coop1 = new Cooperative
            {
                Reference = "C001",
                Description = "Coopérative Nord",
                Email = "nord@coop.tn",
                Telephone = "71234567",
                Password = "pass123"
            };

            var coop2 = new Cooperative
            {
                Reference = "C002",
                Description = "Coopérative Sud",
                Email = "sud@coop.tn",
                Telephone = "76876543",
                Password = "pass456"
            };

            context.Cooperatives.AddRange(coop1, coop2);

            // Add agriculteur
            var agriculteur = new Agriculteur
            {
                CIN = "12345678",
                PrenomNom = "Ali Ben Salem",
                Telephone = "98123456",
                Email = "ali@agr.tn",
                Password = "agri123",
                DateNaissance = new DateTime(1995, 5, 10)
            };

            context.Agriculteurs.Add(agriculteur);

            // Add parcelle
            var parcelle = new Parcelle
            {
                Reference = "P001",
                Superficie = 100,
                Localisation = "Bizerte",
                Sol = TypeSol.SolArgileux,
                Cooperative = coop1
            };

            context.Parcelles.Add(parcelle);

            context.SaveChanges();
        }
    }
}
