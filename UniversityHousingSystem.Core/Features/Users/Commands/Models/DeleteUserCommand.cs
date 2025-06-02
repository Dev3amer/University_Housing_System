using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<bool>>
    {
        public string Id { get; set; } = default!;
    }
}
