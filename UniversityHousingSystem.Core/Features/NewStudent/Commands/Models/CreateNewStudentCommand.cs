using MediatR;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.NewStudent.Commands.Models
{
    public class CreateNewStudentCommand : IRequest<Response<GetNewStudentByIdResponse>>
    {
        public decimal HighSchoolPercentage { get; set; }
        public bool IsOutsideSchool { get; set; }
        public int HighSchoolId { get; set; }
        public int CollageId { get; set; }
        public int CollageDepartmentId { get; set; }
        public int CountryId { get; set; }
        public int VillageId { get; set; }
        public string GuardianFirstName { get; set; } = default!;
        public string GuardianSecondName { get; set; } = default!;
        public string GuardianThirdName { get; set; } = default!;
        public string GuardianFourthName { get; set; } = default!;
        public string GuardianJob { get; set; } = default!;
        public string GuardianNationalId { get; set; } = default!;
        public string GuardianPhone { get; set; } = default!;
        public string GuardianRelation { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? Telephone { get; set; }
        public DateOnly BirthDate { get; set; }
        public EnGender Gender { get; set; }
        public EnReligion Religion { get; set; }
        public string PlaceOfBirth { get; set; } = default!;
        public bool HasSpecialNeeds { get; set; }
        public string AcademicStudentCode { get; set; } = default!;
        public string AcademicYear { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsMarried { get; set; }
        public string AddressLine { get; set; } = default!;
    }
}
