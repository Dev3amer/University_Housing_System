using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.OldStudent.Commands.Models
{
    public class CreateOldStudentCommand : IRequest<Response<GetOldStudentByIdResponse>>
    {
        public int FavRoomId { get; set; }
        public string RegistrationCode { get; set; } = default!;

        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateOnly BirthDate { get; set; }
        public EnGender Gender { get; set; }
        public EnReligion Religion { get; set; }
        public bool IsMarried { get; set; }
        public bool HasSpecialNeeds { get; set; }

        public EnPreviousYearGrade PreviousYearGrade { get; set; }
        public decimal GradePercentage { get; set; }
        public bool PreviousYearHosting { get; set; }
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
