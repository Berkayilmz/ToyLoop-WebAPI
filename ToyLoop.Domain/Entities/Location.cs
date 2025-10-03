namespace ToyLoop.Domain.Entities;

public class Location
{
    public int LocationId { get; set; }
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation property (1 location → n users)
    public ICollection<User> Users { get; set; } = new List<User>();
}