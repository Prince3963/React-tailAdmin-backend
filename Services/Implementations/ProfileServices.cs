using MyDummyAPI.DTOs;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Services.Implementations
{
    public class ProfileServices : IProfileServices
    {
        private readonly IProfileRepo profileRepo;
        public ProfileServices(IProfileRepo profileRepo)
        {
            this.profileRepo = profileRepo;
        }
        public async Task<ProfileDTO> addProfile(ProfileDTO profileDTO)
        {
            var newProfile = new Profile
            {
                UserId = profileDTO.UserId,
                IsPaid = profileDTO.IsPaid,
                Amount = profileDTO.Amount
            };

            var result = await profileRepo.addProfile(newProfile);

            return new ProfileDTO
            {
                UserId = result.UserId,
                Amount = result.Amount,
                IsPaid = result.IsPaid
            };
        }

        public async Task<List<Profile>> getAllProfile()
        {
            return await profileRepo.getAllProfile();
        }
    }
}
