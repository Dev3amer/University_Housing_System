using AutoMapper;

namespace UniversityHousingSystem.Core.Mapping.UserMapping
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            GetUserByIdMapping();
            EditUserMapping();
        }
    }
}
