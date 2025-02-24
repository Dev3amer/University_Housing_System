using Microsoft.AspNetCore.Identity;

namespace UniversityHousingSystem.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? ResetCode { get; set; }
        public Employee? Employee { get; set; }
        public Student? Student { get; set; }
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; } = new HashSet<UserRefreshToken>();

    }
}
