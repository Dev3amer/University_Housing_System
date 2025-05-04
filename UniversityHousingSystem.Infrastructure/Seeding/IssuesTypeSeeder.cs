using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace MovieReservationSystem.Infrastructure.Seeding
{
    public class IssuesTypeSeeder
    {
        private readonly AppDbContext _context;
        public IssuesTypeSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedIssuesTypesAsync()
        {
            var issuesTypes = new List<IssueType>
        {
            new IssueType { TypeName = "السكن والإقامة" },
            new IssueType { TypeName = "مشكلات الصيانة" },
            new IssueType { TypeName = "الطعام والمطعم" },
            new IssueType { TypeName = "النظافة" },
            new IssueType { TypeName = "الأمن والسلامة" },
            new IssueType { TypeName = "إدارية وتسجيل" },
            new IssueType { TypeName = "صحية ونفسية" },
            new IssueType { TypeName = "مقترحات وشكاوى عامة" }
        };

            if (!_context.IssueTypes.Any())
            {
                await _context.IssueTypes.AddRangeAsync(issuesTypes);
                await _context.SaveChangesAsync();
            }
        }
    }
}
