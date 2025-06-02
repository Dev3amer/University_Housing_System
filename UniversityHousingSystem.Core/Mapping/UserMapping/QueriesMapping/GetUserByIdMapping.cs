using UniversityHousingSystem.Core.Features.Users.Queries.Results;
using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<ApplicationUser, GetUserByIdResponse>()
                .ForMember(dist => dist.FullName, option => option.MapFrom(src => src.Student.FirstName +
                                                                                    " " + src.Student.SecondName +
                                                                                    " " + src.Student.ThirdName +
                                                                                    " " + src.Student.FourthName));
        }
    }
}
