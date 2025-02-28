using System.Text.Json;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class CountrySeeder
    {
        private readonly AppDbContext _context;
        private readonly string _contentRootPath;
        public CountrySeeder(AppDbContext context, string contentRootPath)
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
                "Countries",
                "EgyptCountriesCompact.json"
            );
            try
            {
                if (!_context.Countries.Any())
                {
                    // Read from JSON file
                    var countriesData = await File.ReadAllTextAsync(seedDataPath);
                    var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);

                    if (countries == null || countries.Count == 0)
                        return;

                    await _context.Countries.AddRangeAsync(countries);
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
