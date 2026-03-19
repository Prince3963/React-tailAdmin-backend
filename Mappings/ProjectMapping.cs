
using AutoMapper;
using MyDummyAPI.DTOs;
using MyDummyAPI.Models;

namespace MyDummyAPI.Mappings
{
    public class ProjectMapping : AutoMapper.Profile
    {
        public ProjectMapping()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
