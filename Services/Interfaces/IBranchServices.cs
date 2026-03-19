using MyDummyAPI.DTOs;
using MyDummyAPI.HelperServices;
using MyDummyAPI.Models;

namespace MyDummyAPI.Services.Interfaces
{
    public interface IBranchServices
    {
        Task<List<Branch>> getAll();
        Task<ResponseServices<BranchDTO>> addBranch(BranchDTO branchDTO);
    }
}
