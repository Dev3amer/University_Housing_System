using System.Text.Json;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class VillageSeeder
    {
        private readonly AppDbContext _context;
        private readonly string _contentRootPath;
        public VillageSeeder(AppDbContext context, string contentRootPath)
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
                "Villages",
                "EgyptVillagesCompact.json"
            );
            try
            {
                if (!_context.Villages.Any())
                {
                    // Read from JSON file
                    var villagesData = await File.ReadAllTextAsync(seedDataPath);
                    var villages = JsonSerializer.Deserialize<List<Village>>(villagesData);

                    if (villages == null || villages.Count == 0)
                        return;

                    // Use batch insertion for better performance
                    const int batchSize = 1000;
                    for (int i = 0; i < villages.Count; i += batchSize)
                    {
                        var villagesBatch = villages.Skip(i).Take(batchSize);
                        await _context.Villages.AddRangeAsync(villagesBatch);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
