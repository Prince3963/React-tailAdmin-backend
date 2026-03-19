using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDummyAPI.DTOs;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileServices profileServices;
        public ProfilesController(IProfileServices profileServices)
        {
            this.profileServices = profileServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await profileServices.getAllProfile();
            return Ok(result);
        }

        [HttpPost("AddProfile")]
        public async Task<IActionResult> addProfile(ProfileDTO profileDTO)
        {
            var result = await profileServices.addProfile(profileDTO);
            return Ok(result);
        } 
    }
}
