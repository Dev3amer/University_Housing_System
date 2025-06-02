using MediatR;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResponse>>
    {
        public string Id { get; set; } = default!;
    }
}
