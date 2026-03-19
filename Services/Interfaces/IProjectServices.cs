using MyDummyAPI.DTOs;
using MyDummyAPI.Models;

namespace MyDummyAPI.Services.Interfaces
{
    public interface IProjectServices
    {
        Task<List<Project>> getAllProject();
        Task<Project> getProjectById(int id);
        Task<ProjectDTO> addProject(ProjectDTO projectDTO);
        Task<UpdateProjectDTO?> updateProject(int id, UpdateProjectDTO projectDTO);
    }
}
