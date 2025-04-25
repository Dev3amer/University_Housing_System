namespace UniversityHousingSystem.Core.Features.Employees.Queries.Results
{
    public class GetEmployeeByIdResponse
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
    }
}
