using ToyLoop.Domain.Enums;

namespace ToyLoop.Domain.Entities;

public class User
{
    public long UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Phone { get; set; }

    // Location ilişkisi
    public int LocationId { get; set; }
    public Location? Location { get; set; }

    // Role ilişkisi
    public int RoleId { get; set; }
    public Role? Role { get; set; }

    public UserStatus Status { get; set; } = UserStatus.Active;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}