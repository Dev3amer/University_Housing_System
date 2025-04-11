using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.OldStudent.Queries.Results
{
    public class GetOldStudentByIdResponse : SharedDTOs.StudentResponse
    {
        public int OldStudentId { get; set; }
        public EnPreviousYearGrade PreviousYearGrade { get; set; }
        public decimal GradePercentage { get; set; }
        public bool PreviousYearHosting { get; set; }
    }
}
