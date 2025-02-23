using Microsoft.AspNetCore.Identity;

namespace UniversityHousingSystem.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Employee? Employee { get; set; }
        public Student? Student { get; set; }
    }
}
