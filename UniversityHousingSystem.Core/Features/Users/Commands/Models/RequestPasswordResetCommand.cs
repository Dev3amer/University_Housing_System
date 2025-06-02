using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Users.Commands.Models
{
    public class RequestPasswordResetCommand : IRequest<Response<bool>>
    {
        public string Email { get; set; } = default!;
    }
}
