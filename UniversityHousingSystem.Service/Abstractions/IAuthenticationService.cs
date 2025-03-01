using System.IdentityModel.Tokens.Jwt;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Helpers.DTOs;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IAuthenticationService
    {
        Task<JwtAuthTokenResponse> GetJwtTokenAsync(ApplicationUser user);
        JwtSecurityToken ReadJwtToken(string accessToken);
        Task<string>? ValidateBeforeRenewTokenAsync(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        Task<JwtAuthTokenResponse> CreateNewAccessTokenByRefreshToken(string accessToken, UserRefreshToken userRefreshToken);
        Task<string>? ValidateAccessTokenAsync(string accessToken);
        Task<UserRefreshToken> GetUserFullRefreshTokenObjByRefreshToken(string refreshToken);

    }
}
