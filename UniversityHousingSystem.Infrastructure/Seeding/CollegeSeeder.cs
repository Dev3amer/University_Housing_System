using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace MovieReservationSystem.Infrastructure.Seeding
{
    public class CollegeSeeder
    {
        private readonly AppDbContext _context;
        public CollegeSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedCollagesAsync()
        {
            var collages = new List<College>
            {
                new College { Name = "كلية الطب البشري" },
                new College { Name = "كلية الطب البيطري" },
                new College { Name = "كلية العلاج الطبيعي" },
                new College { Name = "كلية التمريض" },
                new College { Name = "كلية الهندسة بشبرا" },
                new College { Name = "كلية الهندسة ببنها" },
                new College { Name = "كلية الحاسبات والذكاء الاصطناعي" },
                new College { Name = "كلية العلوم" },
                new College { Name = "كلية الزراعة" },
                new College { Name = "كلية الفنون التطبيقية" },
                new College { Name = "كلية التجارة" },
                new College { Name = "كلية التربية" },
                new College { Name = "كلية التربية النوعية" },
                new College { Name = "كلية التربية الرياضية" },
                new College { Name = "كلية الحقوق" },
                new College { Name = "كلية الآداب" }
            };

            if (!_context.Colleges.Any())
            {
                await _context.Colleges.AddRangeAsync(collages);
                await _context.SaveChangesAsync();
            }
        }
    }
}
