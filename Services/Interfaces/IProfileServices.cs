using MyDummyAPI.DTOs;
using MyDummyAPI.Models;

namespace MyDummyAPI.Services.Interfaces
{
    public interface IProfileServices
    {
        Task<List<Profile>> getAllProfile();
        Task<ProfileDTO> addProfile(ProfileDTO profileDTO);
    }
}
