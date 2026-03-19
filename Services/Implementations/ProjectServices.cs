using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.DTOs;
using MyDummyAPI.Enums;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Services.Implementations
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepo projectRepo;
        private readonly IUser userRepo;
        private readonly IPartnerRepo partnerRepo;
        private readonly IMapper mapper;
        private readonly AppDbContext dbContext;

        public ProjectServices(IProjectRepo projectRepo, IMapper mapper, AppDbContext dbContext, IUser userRepo, IPartnerRepo partnerRepo) 
        {
            this.projectRepo = projectRepo;
            this.partnerRepo = partnerRepo;
            this.mapper = mapper; 
            this.dbContext = dbContext;
            this.userRepo = userRepo;
        }

        public async Task<ProjectDTO> addProject(ProjectDTO projectDTO)
        {
            // Username find karyu
            var user = await userRepo.getUsername(projectDTO.PartnerName);
            if (user == null)
                throw new Exception("User not found");

            // Check role karyo
            if (user.Role != UserRole.Partner)
                throw new Exception("User is not a Partner");

            // Partner table amthi actual record lidho
            var partner = await partnerRepo.getPartnerById(user.Id);

            if (partner == null)
                throw new Exception("Partner record not found");

            // Map project
            var project = mapper.Map<Project>(projectDTO);

            project.InterviewingUserId = user.Id;
            project.ManagedByPartnerId = partner.Id;

            var result = await projectRepo.addProject(project);

            return mapper.Map<ProjectDTO>(result);
        }

        public async Task<List<Project>> getAllProject()
        {
            return await projectRepo.getAllProject();
        }

        public async Task<Project> getProjectById(int id)
        {
            var result = await projectRepo.getProjectById(id);
            return result;
        }

        public async Task<UpdateProjectDTO?> updateProject(int id, UpdateProjectDTO updateProjectDTO)
        {
            var project = new Project
            {
                Name = updateProjectDTO.Name,
                Description = updateProjectDTO.Description,
                ClientName = updateProjectDTO.ClientName,
                ProjectValue = updateProjectDTO.ProjectValue,
                EndDate = updateProjectDTO.EndDate,
                StartDate = updateProjectDTO.StartDate,
                Status = updateProjectDTO.Status,
                //ManagedByPartnerId = int.Parse(updateProjectDTO.PartnerName),
                //ProfileId = updateProjectDTO.ProfileId,
                TechnologyStack = updateProjectDTO.TechnologyStack,
                ManagerName = updateProjectDTO.ManagerName,
                ManagerEmail = updateProjectDTO.ManagerEmail,
                ManagerContact = updateProjectDTO.ManagerContact,
                LeaveApplyWay =updateProjectDTO.LeaveApplyWay,
                ClientManagerName = updateProjectDTO.ClientManagerName,
                ClientManagerEmail = updateProjectDTO.ClientManagerEmail,
                ClientManagerContact = updateProjectDTO.ClientManagerContact,
                IsSmooth = updateProjectDTO.IsSmooth,
                //MobileNumberUsed = projectDTO.MobileNumberUsed,
                //InterviewingUserId  = projectDTO.InterviewingUserId,
                //IsToolUsed = projectDTO.IsToolUsed


            };

            var result = await projectRepo.updateProject(project, id);

            if (result == null)
            {
                return new UpdateProjectDTO();
            }

            return new UpdateProjectDTO
            {
                Name = result.Name,
                Description = result.Description,
                ClientName = result.ClientName,
                ProjectValue = result.ProjectValue,
                EndDate = result.EndDate,
                StartDate = result.StartDate,
                Status = result.Status,
                //PartnerName = result.ManagedByPartnerId.ToString(),
                //ProfileId = result.ProfileId,
                TechnologyStack = result.TechnologyStack,
                ManagerName = result.ManagerName,
                ManagerEmail = result.ManagerEmail,
                ManagerContact = result.ManagerContact,
                LeaveApplyWay = result.LeaveApplyWay,
                ClientManagerName = result.ClientManagerName,
                ClientManagerEmail = result.ClientManagerEmail,
                ClientManagerContact = result.ClientManagerContact,
                IsSmooth = result.IsSmooth,
                //MobileNumberUsed = result.MobileNumberUsed,
                //InterviewingUserId = result.InterviewingUserId,
                //IsToolUsed = result.IsToolUsed
            };
        }
    }
}
