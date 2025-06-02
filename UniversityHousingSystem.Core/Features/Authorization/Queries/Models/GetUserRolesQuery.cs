using MediatR;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authorization.Queries.Models
{
    public class GetUserRolesQuery : IRequest<Response<GetUserRolesResponse>>
    {
        public string userId { get; set; } = default!;
    }
}
