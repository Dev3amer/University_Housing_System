using MediatR;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authorization.Queries.Models
{
    public class GetAllRolesQuery : IRequest<Response<List<GetAllRolesResponse>>>
    {
    }
}
