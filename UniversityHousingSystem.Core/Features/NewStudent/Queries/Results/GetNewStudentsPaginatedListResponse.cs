namespace UniversityHousingSystem.Core.Features.NewStudent.Queries.Results
{
    public class GetNewStudentsPaginatedListResponse : SharedDTOs.StudentResponse
    {
        public int NewStudentId { get; set; }
        public decimal HighSchoolPercentage { get; set; }
        public int HighSchoolId { get; set; }
        public string HighSchoolName { get; set; } = default!;
    }
}
