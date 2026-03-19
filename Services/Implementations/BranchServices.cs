using MyDummyAPI.DTOs;
using MyDummyAPI.HelperServices;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Services.Implementations
{
    public class BranchServices : IBranchServices
    {
        private readonly IBranchRepo brachRepo;

        public BranchServices(IBranchRepo branchRepo)
        {
            this.brachRepo = branchRepo;
        }
        public async Task<ResponseServices<BranchDTO>> addBranch(BranchDTO branchDTO)
        {
            var response = new ResponseServices<BranchDTO>();
            try
            {
                var newBranch = new Branch
                {
                    Name = branchDTO.Name,
                    Location = branchDTO.Location,
                    Description = branchDTO.Description,
                    IsActive = branchDTO.IsActive,
                };

                var result = await brachRepo.addBranch(newBranch);

                response.data = new BranchDTO
                {
                    Name = result.Name,
                    Location = result.Location,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
                response.message = "Branch successfully added";
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.data = new BranchDTO();
                response.message = ex.Message;
                response.status = false;
                return response;
            }
        }

        public async Task<List<Branch>> getAll()
        {
            return await brachRepo.getAll();
        }
    }
}
