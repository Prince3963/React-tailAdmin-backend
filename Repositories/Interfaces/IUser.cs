using MyDummyAPI.Models;

namespace MyDummyAPI.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<User>> getAllUser();
        Task<User> getById(int id);
        Task<User> existEmail(string email);
        Task<User> getUsername(string username);
        Task<User> deleteUser(int id);
        Task<User> updateUser(int id, User user);
    }
}
