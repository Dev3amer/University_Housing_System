using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.NewStudent.Commands.Models
{
    public class CreateNewStudentCommand : IRequest<Response<GetNewStudentByIdResponse>>
    {
        public int FavRoomId { get; set; }
        public string RegistrationCode { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public bool HasSpecialNeeds { get; set; }
        public DateOnly BirthDate { get; set; }
        public EnGender Gender { get; set; }
        public EnReligion Religion { get; set; }
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsMarried { get; set; }


        public decimal HighSchoolPercentage { get; set; }
        public int HighSchoolId { get; set; }
        public int CollageId { get; set; }
        public int CollageDepartmentId { get; set; }
        public string AcademicStudentCode { get; set; } = default!;
        public string AcademicYear { get; set; } = default!;

        public int CountryId { get; set; }
        public int GovernorateId { get; set; }
        public int CityId { get; set; }
        public int VillageId { get; set; }

        public string GuardianFirstName { get; set; } = default!;
        public string GuardianSecondName { get; set; } = default!;
        public string GuardianThirdName { get; set; } = default!;
        public string GuardianFourthName { get; set; } = default!;
        public string GuardianJob { get; set; } = default!;
        public string GuardianNationalId { get; set; } = default!;
        public string GuardianPhone { get; set; } = default!;
        public string GuardianRelation { get; set; } = default!;

        public IFormFile NationalIdImage { get; set; } = default!;
        public IFormFile GuardianNationalIdImage { get; set; } = default!;
        public IFormFile PersonalImage { get; set; } = default!;
        public IFormFile WaterBill { get; set; } = default!;
        public IFormFile ResidenceApplication { get; set; } = default!;
    }
}
