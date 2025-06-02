using MediatR;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.DTOs;

namespace UniversityHousingSystem.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthTokenResponse>>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
