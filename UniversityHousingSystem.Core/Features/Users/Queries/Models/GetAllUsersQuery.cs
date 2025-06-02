using MediatR;
using UniversityHousingSystem.Core.Features.Users.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Users.Queries.Models
{
    public class GetAllUsersQuery : IRequest<Response<List<GetAllUsersResponse>>>
    {
    }
}
