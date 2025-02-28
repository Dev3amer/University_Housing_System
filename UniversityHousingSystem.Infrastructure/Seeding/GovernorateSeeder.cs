using System.Text.Json;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class GovernorateSeeder
    {
        private readonly AppDbContext _context;
        private readonly string _contentRootPath;
        public GovernorateSeeder(AppDbContext context, string contentRootPath)
        {
            _context = context;
            _contentRootPath = contentRootPath;
        }

        public async Task SeedAsync()
        {
            // Use IWebHostEnvironment to get the correct path
            var seedDataPath = Path.Combine(
                _contentRootPath,
                "UniversityHousingSystem.Infrastructure",
                "Seeding",
                "Json",
                "Governorates",
                "EgyptGovernoratesCompact.json"
            );
            try
            {
                if (!_context.Governorates.Any())
                {
                    // Read from JSON file
                    var governoratesData = await File.ReadAllTextAsync(seedDataPath);
                    var governorates = JsonSerializer.Deserialize<List<Governorate>>(governoratesData);

                    if (governorates == null || governorates.Count == 0)
                        return;

                    await _context.Governorates.AddRangeAsync(governorates);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
