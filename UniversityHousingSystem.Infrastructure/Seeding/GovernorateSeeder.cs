using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class GovernorateSeeder
    {
        private readonly AppDbContext _context;
        public GovernorateSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Use IWebHostEnvironment to get the correct path
            var seedDataPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Seeding",
                "Json",
                "Governorates",
                "EgyptGovernoratesCompact.json"
            );
            try
            {
                if (!await _context.Governorates.AnyAsync())
                {
                    // Read from JSON file
                    var governoratesData = await File.ReadAllTextAsync(seedDataPath);
                    var governorates = JsonConvert.DeserializeObject<List<Governorate>>(governoratesData);

                    if (governorates == null || governorates.Count == 0)
                        return;
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        // Enable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Governorates ON;");

                        await _context.Governorates.AddRangeAsync(governorates);
                        await _context.SaveChangesAsync();

                        // Disable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Governorates OFF;");

                        await transaction.CommitAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
