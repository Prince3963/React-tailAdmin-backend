using System.Text.Json.Serialization;
using MyDummyAPI.Enums;

namespace MyDummyAPI.Models
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? MobileNumber { get; set; }
        public string? EmergencyMobileNumber { get; set; }
        public UserGender Gender { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        public Profile? Profile { get; set; }

        [JsonIgnore]
        public Partner? Partner { get; set; }
        
        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}
