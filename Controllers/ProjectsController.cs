using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDummyAPI.DTOs;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectServices projectServices;
        public ProjectsController(IProjectServices projectServices)
        {
            this.projectServices = projectServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await projectServices.getAllProject();
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await projectServices.getProjectById(id);
            return Ok(result);
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject(ProjectDTO projectDTO)
        {
            var result = await projectServices.addProject(projectDTO);
            return Ok(result);
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> updateProject(int id,[FromBody] UpdateProjectDTO updateProjectDTO)
        {

            var result = await projectServices.updateProject(id, updateProjectDTO);
            return Ok(result);
        }
    }
}
