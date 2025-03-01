namespace UniversityHousingSystem.Data.Helpers.DTOs
{
    public class JwtAuthTokenResponse
    {
        public string UserId { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public RefreshTokenInJwtAuthTokeResponse RefreshToken { get; set; } = new();
    }
    public class RefreshTokenInJwtAuthTokeResponse
    {
        public string UserName { get; set; } = default!;
        public string TokenString { get; set; } = default!;
        public DateTime ExpireAt { get; set; }
    }
}
