using MyDummyAPI.Enums;

namespace MyDummyAPI.DTOs
{
    public class UpdateUserDTO
    {
        public string? Username { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? MobileNumber { get; set; }
        public string? EmergencyMobileNumber { get; set; }
        public UserGender Gender { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
