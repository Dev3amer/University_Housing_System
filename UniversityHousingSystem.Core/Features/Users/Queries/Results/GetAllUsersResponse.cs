namespace UniversityHousingSystem.Core.Features.Users.Queries.Results
{
    public class GetAllUsersResponse
    {
        public string Id { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
