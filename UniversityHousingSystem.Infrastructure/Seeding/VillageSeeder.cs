using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class VillageSeeder
    {
        private readonly AppDbContext _context;
        public VillageSeeder(AppDbContext context)
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

                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        // Enable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Villages ON");

                        // Use batch insertion for better performance
                        const int batchSize = 1000;
                        for (int i = 0; i < villages.Count; i += batchSize)
                        {
                            var villagesBatch = villages.Skip(i).Take(batchSize);
                            await _context.Villages.AddRangeAsync(villagesBatch);
                            await _context.SaveChangesAsync();
                        }

                        // Disable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Villages OFF");

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
