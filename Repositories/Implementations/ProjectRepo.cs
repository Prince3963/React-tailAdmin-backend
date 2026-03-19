using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;

namespace MyDummyAPI.Repositories.Implementations
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly AppDbContext dbContext;
        public ProjectRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Project> addProject(Project project)
        {
            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<List<Project>> getAllProject()
        {
            return await dbContext.Projects.ToListAsync();
        }

        public async Task<Project> getProjectById(int id)
        {
            var existProject = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (existProject == null)
            {
                return new Project();
            }

            return existProject;
        }

        public async Task<Project> updateProject(Project project, int id)
        {
            var existingProject = await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProject == null)
            {
                return null;
            }

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.ClientName = project.ClientName;
            existingProject.ProjectValue = project.ProjectValue;
            existingProject.EndDate = project.EndDate;
            existingProject.StartDate = project.StartDate;
            existingProject.Status = project.Status;
            //existingProject.ManagedByPartnerId = project.ManagedByPartnerId;
            existingProject.TechnologyStack = project.TechnologyStack;
            existingProject.ManagerName = project.ManagerName;
            existingProject.ManagerEmail = project.ManagerEmail;
            existingProject.ManagerContact = project.ManagerContact;
            existingProject.LeaveApplyWay = project.LeaveApplyWay;
            existingProject.ClientManagerName = project.ClientManagerName;
            existingProject.ClientManagerEmail = project.ClientManagerEmail;
            existingProject.ClientManagerContact = project.ClientManagerContact;
            existingProject.IsSmooth = project.IsSmooth;


            await dbContext.SaveChangesAsync();

            return existingProject;
        }
    }
}
