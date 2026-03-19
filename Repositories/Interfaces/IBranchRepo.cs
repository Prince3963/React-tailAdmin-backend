using MyDummyAPI.Models;

namespace MyDummyAPI.Repositories.Interfaces
{
    public interface IBranchRepo
    {
        Task<List<Branch>> getAll();
        Task<Branch> addBranch(Branch branch);
    }
}
