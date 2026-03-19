using MyDummyAPI.Models;

namespace MyDummyAPI.Repositories.Interfaces
{
    public interface IProfileRepo
    {
        Task<List<Profile>> getAllProfile();
        Task<Profile> addProfile(Profile profile);
    }
}
