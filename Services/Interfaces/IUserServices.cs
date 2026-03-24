using MyDummyAPI.DTOs;
using MyDummyAPI.HelperServices;
using MyDummyAPI.Models;

namespace MyDummyAPI.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> getAllUsers();
        Task<ResponseServices<User>> getUserById(int id);
        Task<ResponseServices<UserDTO>> addUser(UserDTO userDTO);
        Task<ResponseServices<LoginDTO>> existEmail(LoginDTO loginDTO);
        Task<ResponseServices<User>> softDelete(int id);
        Task<ResponseServices<UpdateUserDTO>> updateUser(int id, UpdateUserDTO userDTO);
    }
}
