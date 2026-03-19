using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.DTOs;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;

namespace MyDummyAPI.Repositories.Implementations
{
    public class UserRepo : IUser
    {
        private readonly AppDbContext dbContext;
        public UserRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> addUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> getAllUser()
        {
            var result = await dbContext.Users.ToListAsync();
            return result;
        }

        public async Task<User> existEmail(string email)
        {
            var existEmail = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (existEmail == null)
            {
                return new User();
            }
            return existEmail;
        }

        public async Task<User> getUsername(string username)
        {
            var result = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            return result;
        }
    }
}
