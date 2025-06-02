using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Data.Helpers.DTOs
{
    public class CreateUserResult
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
        public bool Succeeded => Errors == null || !Errors.Any();
    }
}
