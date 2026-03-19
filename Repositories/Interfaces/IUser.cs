using MyDummyAPI.Models;

namespace MyDummyAPI.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<User>> getAllUser();
        Task<User> addUser(User user);
        Task<User> existEmail(string email);
        Task<User> getUsername(string username);
    }
}
