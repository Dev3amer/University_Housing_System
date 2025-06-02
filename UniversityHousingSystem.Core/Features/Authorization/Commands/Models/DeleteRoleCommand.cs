using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<bool>>
    {
        public string RoleId { get; set; } = default!;
    }
}
