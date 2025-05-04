using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace MovieReservationSystem.Infrastructure.Seeding
{
    public class HighSchoolsSeeder
    {
        private readonly AppDbContext _context;
        public HighSchoolsSeeder(AppDbContext context)
        {
            _context = context;
        }
        public async Task SeedHighSchoolsAsync()
        {
            var highSchools = new List<HighSchool>
            {
                new HighSchool { Name = "ثانوي عام شعبة علمي علوم" },
                new HighSchool { Name = "ثانوي عام شعبة علمي رياضة" },
                new HighSchool { Name = "ثانوي عام شعبة أدبى" },
                new HighSchool { Name = "أزهري علمي" },
                new HighSchool { Name = "أزهري أدبى" },
                new HighSchool { Name = "مدارس فنية ثلاث سنوات" },
                new HighSchool { Name = "مدارس فنية أربع سنوات" },
                new HighSchool { Name = "مدارس فنية خمس سنوات" },
                new HighSchool { Name = "المدارس التكنولوجية التطبيقية" },
                new HighSchool { Name = "مدارس المتفوقين في العلوم والتكنولوجيا (STEM)" },
                new HighSchool { Name = "مدارس النيل الدولية" },
                new HighSchool { Name = "شهادة معادلة" }
            };

            if (!_context.HighSchools.Any())
            {
                await _context.HighSchools.AddRangeAsync(highSchools);
                await _context.SaveChangesAsync();
            }
        }
    }
}
