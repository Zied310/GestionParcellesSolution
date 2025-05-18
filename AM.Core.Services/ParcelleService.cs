using AM.Core.Domaine;
using Microsoft.EntityFrameworkCore;

public class ParcelleService
{
    private readonly ParcelleDbContext _context;

    public ParcelleService(ParcelleDbContext context)
    {
        _context = context;
    }

    // 5. Get gain of a cooperative
    public async Task<double> GetGainAsync(string cooperativeReference)
    {
        var gain = await _context.Agricultures
            .Include(a => a.Parcelle)
            .Where(a => a.Parcelle.CooperativeReference == cooperativeReference)
            .SumAsync(a => a.PrixLocationParcelle);

        return gain;
    }

    // 6. Get list of young agriculteurs (18 <= age <= 35)
    public async Task<List<Agriculteur>> GetYoungAgriculteursAsync()
    {
        var today = DateTime.Today;
        var minDate = today.AddYears(-35); // born after this date (younger than 35)
        var maxDate = today.AddYears(-18); // born before this date (older than 18)

        return await _context.Agriculteurs
            .Where(a => a.DateNaissance >= minDate && a.DateNaissance <= maxDate)
            .ToListAsync();
    }

    // 7. Get list of parcelles currently in culture (with ongoing agriculture)
    public async Task<List<Parcelle>> GetParcellesInCultureAsync()
    {
        var today = DateTime.Today;

        var parcelles = await _context.Parcelles
            .Where(p => p.Agricultures.Any(a => a.DatePlantation <= today && a.DateRecolte >= today))
            .ToListAsync();

        return parcelles;
    }
}
