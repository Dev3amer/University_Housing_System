using MediatR;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.OldStudent.Commands.Models
{
    public class CreateOldStudentCommand : SharedDTOs.StudentResponse,
        IRequest<Response<GetOldStudentByIdResponse>>
    {
        public EnPreviousYearGrade PreviousYearGrade { get; set; }
        public decimal GradePercentage { get; set; }
        public bool PreviousYearHosting { get; set; }
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
