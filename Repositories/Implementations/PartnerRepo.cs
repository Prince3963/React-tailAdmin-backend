using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;

namespace MyDummyAPI.Repositories.Implementations
{
    public class PartnerRepo : IPartnerRepo
    {
        private readonly AppDbContext dbContext;
        public PartnerRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Partner> addPartner(Partner partner)
        {
            await dbContext.Partners.AddAsync(partner);
            await dbContext.SaveChangesAsync();
            return partner;
        }

        public async Task<List<Partner>> getAllPartner()
        {
            return await dbContext.Partners
                .ToListAsync();
        }

        public async Task<Partner> getPartnerById(int id)
        {
            var result = await dbContext.Partners.FirstOrDefaultAsync(x => x.UserId == id);
            return result;
        }
    }
}
