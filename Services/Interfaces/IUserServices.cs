using MyDummyAPI.DTOs;
using MyDummyAPI.HelperServices;
using MyDummyAPI.Models;

namespace MyDummyAPI.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> getAllUsers();
        Task<ResponseServices<UserDTO>> addUser(UserDTO userDTO);
        Task<ResponseServices<LoginDTO>> existEmail(LoginDTO loginDTO);
    }
}
