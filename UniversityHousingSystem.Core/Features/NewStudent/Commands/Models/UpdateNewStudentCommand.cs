using MediatR;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.NewStudent.Commands.Models
{
    public class UpdateNewStudentCommand : SharedDTOs.StudentResponse,
        IRequest<Response<GetNewStudentByIdResponse>>
    {
        public int NewStudentId { get; set; }
        public decimal HighSchoolPercentage { get; set; }
        public bool IsOutsideSchool { get; set; }
        public int CollageId { get; set; }
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
    }
}
