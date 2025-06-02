namespace UniversityHousingSystem.Core.Features.Authorization.Queries.Results
{
    public class GetUserRolesResponse
    {
        public string UserId { get; set; } = default!;
        public List<RolesInUserRolesResponse> Roles { get; set; } = [];
    }
    public class RolesInUserRolesResponse
    {
        public string RoleId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool HasRole { get; set; }
    }
}
