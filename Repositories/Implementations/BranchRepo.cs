using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;

namespace MyDummyAPI.Repositories.Implementations
{
    public class BranchRepo : IBranchRepo
    {
        private readonly AppDbContext dbContext;
        public BranchRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Branch> addBranch(Branch branch)
        {
            await dbContext.Branches.AddAsync(branch);
            await dbContext.SaveChangesAsync();
            return branch;
        }

        public async Task<List<Branch>> getAll()
        {
            return await dbContext.Branches.ToListAsync();
        }
    }
}
