namespace ECommerceApp.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        // Navigation Properties
        public UserProfile? Profile { get; set; }
        public List<Order> Orders { get; set; } = new();
        public List<RefreshToken> RefreshTokens { get; set; } = new();
    }
}