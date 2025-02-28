using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class CountrySeeder
    {
        private readonly AppDbContext _context;
        public CountrySeeder(AppDbContext context)
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
            "Countries",
            "CountriesCompact.json"
             );
            try
            {
                if (!await _context.Countries.AnyAsync())
                {
                    // Read from JSON file
                    var countriesData = await File.ReadAllTextAsync(seedDataPath);
                    var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);

                    if (countries == null || countries.Count == 0)
                        return;

                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        // Enable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Countries ON");

                        await _context.Countries.AddRangeAsync(countries);
                        await _context.SaveChangesAsync();

                        // Disable identity insert
                        await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Countries OFF");

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
