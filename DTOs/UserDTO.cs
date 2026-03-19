using MyDummyAPI.Enums;

namespace MyDummyAPI.DTOs
{
    public class UserDTO
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

        // Employee fields (optional)
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int BranchId { get; set; }


        // Partner fields (optional)
        public decimal? SharePercentage { get; set; }
        public string? PartnershipType { get; set; }
    }
}
