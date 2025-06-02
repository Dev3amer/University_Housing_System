using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Users.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Response<bool>>
    {
        public string Email { get; set; } = default!;
        public string ResetCode { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}
