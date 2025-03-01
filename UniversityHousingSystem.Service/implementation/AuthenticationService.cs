using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Helpers;
using UniversityHousingSystem.Data.Helpers.DTOs;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructors
        public AuthenticationService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository
            , UserManager<ApplicationUser> userManager)
        {
            _jwtSettings = jwtSettings;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
        }
        #endregion

        #region Actions
        public async Task<JwtAuthTokenResponse> GetJwtTokenAsync(ApplicationUser user)
        {
            var jwtToken = await GenerateJwtSecurityTokenAsync(user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var savedUserRefreshToken = await SaveUserRefreshTokenAsync(user, accessToken, jwtToken.Id);

            var refreshTokenForResponse = GetRefreshTokenForResponse(savedUserRefreshToken.ExpiryDate, user.UserName, savedUserRefreshToken.RefreshToken);

            return new JwtAuthTokenResponse()
            {
                UserId = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshTokenForResponse
            };
        }
        private async Task<JwtSecurityToken> GenerateJwtSecurityTokenAsync(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = GetClaims(user, userRoles.ToList());

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtToken = new JwtSecurityToken
            (
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.accessTokenExpireDateInMinutes),
                signingCredentials: signingCred
            );
            return jwtToken;
        }
        private IEnumerable<Claim> GetClaims(ApplicationUser user, List<string> userRoles)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
            };
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private async Task<UserRefreshToken> SaveUserRefreshTokenAsync(ApplicationUser user, string accessToken, string jwtTokenId)
        {
            var userRefreshToken = new UserRefreshToken()
            {
                User = user,
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(_jwtSettings.refreshTokenExpireDateInDays),
                IsRevoked = false,
                IsUsed = true,
                RefreshToken = GenerateRefreshTokenString(),
                AccessToken = accessToken,
                JwtId = jwtTokenId
            };
            var savedUserRefreshToken = await _refreshTokenRepository.AddAsync(userRefreshToken);

            return savedUserRefreshToken;
        }
        private string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private RefreshTokenInJwtAuthTokeResponse GetRefreshTokenForResponse(DateTime ExpiryDate, string userName, string tokenString)
        {
            var refreshToken = new RefreshTokenInJwtAuthTokeResponse()
            {
                ExpireAt = ExpiryDate,
                UserName = userName,
                TokenString = tokenString
            };
            return refreshToken;
        }

        public async Task<JwtAuthTokenResponse> CreateNewAccessTokenByRefreshToken(string accessToken, UserRefreshToken userRefreshToken)
        {

            // Generate JWT Security Token
            //var user = await _userManager.FindByIdAsync(userRefreshToken.userID);
            var userId = ReadJwtToken(accessToken).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);

            var generatedJwtSecurityToken = await GenerateJwtSecurityTokenAsync(user);
            var NewAccessToken = new JwtSecurityTokenHandler().WriteToken(generatedJwtSecurityToken);


            var refreshTokenForResponse = GetRefreshTokenForResponse(userRefreshToken.ExpiryDate, user.UserName, userRefreshToken.RefreshToken);


            userRefreshToken.AccessToken = NewAccessToken;
            await _refreshTokenRepository.UpdateAsync(userRefreshToken);

            return new JwtAuthTokenResponse()
            {
                AccessToken = NewAccessToken,
                RefreshToken = refreshTokenForResponse
            };
        }
        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            var handler = new JwtSecurityTokenHandler();

            var response = handler.ReadJwtToken(accessToken);
            return response;
        }

        public async Task<string>? ValidateBeforeRenewTokenAsync(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            //Validations AccessToken
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                return string.Format(SharedResourcesKeys.Invalid, "Hash Algorithm");
            if (jwtToken.ValidTo > DateTime.UtcNow)
                return SharedResourcesKeys.NotExpiredToken;

            //Get User RefreshToken
            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var userRefreshToken = await _refreshTokenRepository.GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.AccessToken == accessToken && x.RefreshToken == refreshToken && x.UserId == userId);

            //Validations User Refresh Token
            if (userRefreshToken == null)
                return SharedResourcesKeys.InvalidRefreshToken;

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return SharedResourcesKeys.ExpiredRefreshToken;
            }
            return null;
        }
        public async Task<string>? ValidateAccessTokenAsync(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                    return SharedResourcesKeys.InvalidToken;
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<UserRefreshToken> GetUserFullRefreshTokenObjByRefreshToken(string refreshToken)
        {
            return await _refreshTokenRepository.GetTableAsTracking()
                .Where(r => r.RefreshToken == refreshToken)
                .FirstOrDefaultAsync();
        }
        #endregion
    }
}