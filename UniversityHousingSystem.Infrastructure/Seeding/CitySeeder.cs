using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class CitySeeder
    {
        private readonly AppDbContext _context;
        public CitySeeder(AppDbContext context)
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
                "Cities",
                "EgyptCitiesCompact.json"
            );
            try
            {
                if (!_context.Cities.Any())
                {
                    // Read from JSON file
                    var citiesData = await File.ReadAllTextAsync(seedDataPath);
                    var cities = JsonSerializer.Deserialize<List<City>>(citiesData);

                    if (cities == null || cities.Count == 0)
                        return;
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        // Enable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Cities ON");

                        // Use batch insertion for better performance
                        const int batchSize = 100;
                        for (int i = 0; i < cities.Count; i += batchSize)
                        {
                            var citiesBatch = cities.Skip(i).Take(batchSize);
                            await _context.Cities.AddRangeAsync(citiesBatch);
                            await _context.SaveChangesAsync();
                        }

                        // Disable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Cities OFF");

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
