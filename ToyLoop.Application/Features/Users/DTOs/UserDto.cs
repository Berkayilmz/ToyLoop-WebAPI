namespace ToyLoop.Application.Features.Users.DTOs
{
    public class UserDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Navigation’dan sadece ihtiyacımız olan bilgileri taşıyoruz
        public string RoleName { get; set; }
        public string Location { get; set; }
    }
}