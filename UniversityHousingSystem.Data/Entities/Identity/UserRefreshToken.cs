namespace UniversityHousingSystem.Data.Entities.Identity
{
    public class UserRefreshToken
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public string? AccessToken { get; set; } = default!;
        public string? RefreshToken { get; set; } = default!;
        public string? JwtId { get; set; } = default!;
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public virtual ApplicationUser User { get; set; } = new();
    }
}
