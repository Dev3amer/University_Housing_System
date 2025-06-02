using MediatR;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : IRequest<Response<GetUserRolesResponse>>
    {
        public string UserId { get; set; } = default!;
        public List<string> RolesNames { get; set; } = [];
    }
}
