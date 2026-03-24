using MyDummyAPI.Models;

namespace MyDummyAPI.Repositories.Interfaces
{
    public interface IProjectRepo
    {
        Task<List<Project>> getAllProject();
        Task<Project> getProjectById(int id);
        Task<Project> addProject(Project project);
        Task<Project> updateProject(Project project, int id);
        Task<Project> softDelete(int id);
    }
}
