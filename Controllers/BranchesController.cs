using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDummyAPI.DTOs;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchServices branchServices;
        public BranchesController(IBranchServices branchServices)
        {
            this.branchServices = branchServices;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await branchServices.getAll();
            return Ok(result);
        }

        [HttpPost("AddBranch")]
        public async Task<IActionResult> addBranch(BranchDTO branchDTO)
        {
            var resul = await branchServices.addBranch(branchDTO);
            return Ok(resul);
        }
    }
}
