using UniversityHousingSystem.Core.Features.Users.Commands.Models;
using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, ApplicationUser>();
        }
    }
}
