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

        public async Task<List<User>> getAllUser()
        {
            var result = await dbContext.Users
                .Where(u => u.IsDeleted == false)
                .Include(u => u.Employee)
                .Include(u => u.Partner)
                .ToListAsync();
            return result;
        }

        public async Task<User> existEmail(string email)
        {
            var existEmail = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return existEmail;
        }

        public async Task<User> getUsername(string username)
        {
            var result = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            return result;
        }

        public async Task<User> getById(int id)
        {
            var existUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted == false);
            if (existEmail == null)
            {
                return null;
            }

            return existUser;
        }

        public async Task<User> deleteUser(int id)
        {
            var existUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existUser == null || existUser.IsDeleted == true)
            {
                throw new Exception("Invalid Id User does't exist");
            }

            existUser.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            return existUser;
        }

        public async Task<User> updateUser(int id, User user)
        {
            var existUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existUser == null || existUser.IsDeleted == true)
            {
                throw new Exception("Invalid Id User does't exist");
            }

            existUser.Username = user.Username;
            existUser.FirstName = user.FirstName;
            existUser.LastName = user.LastName;
            existUser.Email = user.Email;
            existUser.Role = user.Role;
            existUser.Gender = user.Gender;
            existUser.MobileNumber = user.MobileNumber;
            existUser.EmergencyMobileNumber = user.EmergencyMobileNumber;
            existUser.IsActive = user.IsActive;

            await dbContext.SaveChangesAsync();
            return existUser;
        }
    }
}
