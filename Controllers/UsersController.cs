using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDummyAPI.DTOs;
using MyDummyAPI.Services.Implementations;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices userServices;
        public UsersController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> getAllUser()
        {
            var result = await userServices.getAllUsers();
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> addUser(UserDTO userDTO)
        {
            var result = await userServices.addUser(userDTO);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> loginUser(LoginDTO loginDTO)
        {
            var result = await userServices.existEmail(loginDTO);
            return Ok(result);
        }
    }
}
