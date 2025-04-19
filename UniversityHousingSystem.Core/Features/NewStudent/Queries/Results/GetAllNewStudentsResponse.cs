using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.NewStudent.Queries.Results
{
    public class GetAllNewStudentsResponse : SharedDTOs.StudentResponse
    {
        public int NewStudentId { get; set; }
        public decimal HighSchoolPercentage { get; set; }
        public bool IsOutsideSchool { get; set; }
        public int HighSchoolId { get; set; }
        public string HighSchoolName { get; set; } = default!;
    }
}
