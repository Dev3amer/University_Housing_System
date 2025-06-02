using MediatR;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authorization.Commands.Models
{
    public class CreateRoleCommand : IRequest<Response<GetRoleByIdResponse>>
    {
        public string Name { get; set; } = default!;
    }
}
