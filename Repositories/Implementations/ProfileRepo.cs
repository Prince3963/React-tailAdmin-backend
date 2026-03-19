using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;

namespace MyDummyAPI.Repositories.Implementations
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly AppDbContext dbContext;

        public ProfileRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Profile> addProfile(Profile profile)
        {
            await dbContext.Profiles.AddAsync(profile);
            await dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<List<Profile>> getAllProfile()
        {
            return await dbContext.Profiles.ToListAsync();
        }
    }
}
