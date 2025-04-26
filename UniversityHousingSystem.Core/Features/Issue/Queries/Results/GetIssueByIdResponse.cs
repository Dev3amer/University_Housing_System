namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetIssueByIdResponse
    {
        public int IssueID { get; set; }
        public string Description { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ResponseDate { get; set; }
        public string? Response { get; set; }
        public int IssuTypeID { get; set; }
        public string IssueTypeName { get; set; } = default!; 

        public int StudentId { get; set; }
        public string StudentName { get; set; } = default!;   // 🆕

        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }

    }

    

}
