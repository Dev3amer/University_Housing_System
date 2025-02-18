using Microsoft.EntityFrameworkCore;

namespace UniversityHousingSystem.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

    }
}
