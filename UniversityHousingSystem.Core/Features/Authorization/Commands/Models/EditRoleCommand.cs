using MediatR;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : IRequest<Response<GetRoleByIdResponse>>
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
