using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.DTOs;
using MyDummyAPI.Enums;
using MyDummyAPI.HelperServices;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;
using MyDummyAPI.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyDummyAPI.Services.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly IUser userRepo;
        private readonly AppDbContext dbContext;

        public UserServices(IUser userRepo, AppDbContext dbContext)
        {
            this.userRepo = userRepo;
            this.dbContext = dbContext;
        }

        public async Task<ResponseServices<UserDTO>> addUser(UserDTO userDTO)
        {
            var response = new ResponseServices<UserDTO>();

            //Atle k jo save user ma save thay to j partner ma pn save thay 
            var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                if (userDTO.Role == UserRole.Employee)
                {
                    if (userDTO.BranchId == null)
                        throw new Exception("BranchId is required for Employee");

                    //Check karyu k aa BranhId no record exist kare 6e k ni 
                    var branchExists = await dbContext.Branches
                        // AnyAsync na use thi aapre khali exist kare 6e k ni te lavya - fast 6e
                        .AnyAsync(b => b.Id == userDTO.BranchId);

                    // firstOrDefault no use karvathi aapre aakhu model jote - slow 6e

                    if (!branchExists)
                        throw new Exception("Invalid BranchId");
                }

                // 1️ Create User 
                var newUser = new User
                {
                    Username = userDTO.Username,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    MobileNumber = userDTO.MobileNumber,
                    Gender = userDTO.Gender,
                    PasswordHash = userDTO.PasswordHash,
                    EmergencyMobileNumber = userDTO.EmergencyMobileNumber,
                    Role = userDTO.Role,
                    IsActive = userDTO.IsActive,
                };


                await dbContext.Users.AddAsync(newUser);
                await dbContext.SaveChangesAsync();

                // 2️ Role based insert
                if (newUser.Role == UserRole.Employee)
                {
                    var employee = new Employee
                    {
                        UserId = newUser.Id,
                        BranchId = userDTO.BranchId,
                        EmployeeCode = "EMP" + newUser.Id,
                        Department = userDTO.Department ?? "",
                        Position = userDTO.Position ?? "",
                        JoinDate = DateTime.Now,
                        IsActive = true
                    };

                    await dbContext.Employees.AddAsync(employee);
                }
                else if (newUser.Role == UserRole.Partner)
                {
                    var partner = new Partner
                    {
                        UserId = newUser.Id,
                        PartnershipType = userDTO.PartnershipType ?? "",
                        SharePercentage = userDTO.SharePercentage ?? 0,
                        BranchId = userDTO.BranchId
                    };

                    await dbContext.Partners.AddAsync(partner);
                }

                // 3️ Save all changes
                await dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                // 4️ Response
                response.data = new UserDTO
                {
                    Username = newUser.Username,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    MobileNumber = newUser.MobileNumber,
                    PasswordHash = newUser.PasswordHash,
                    Gender = newUser.Gender,
                    EmergencyMobileNumber = newUser.EmergencyMobileNumber,
                    Role = newUser.Role,
                    IsActive = newUser.IsActive
                };

                response.message = "User created successfully";
                response.status = true;

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                response.data = null;
                response.message = ex.Message;
                response.status = false;

                return response;
            }
        }

        public async Task<ResponseServices<LoginDTO>> existEmail(LoginDTO loginDTO)
        {
            var response = new ResponseServices<LoginDTO>();

            var user = await userRepo.existEmail(loginDTO.Email);

            if (user == null)
            {
                response.message = "Email does not exist";
                response.status = false;
                return response;
            }

            if (user.PasswordHash != loginDTO.PasswordHash)
            {
                response.message = "Invalid credentials";
                response.status = false;
                return response;
            }

            response.data = new LoginDTO
            {
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };

            response.message = "Login successful";
            response.status = true;

            return response;
        }

        public async Task<List<User>> getAllUsers()
        {
            return await userRepo.getAllUser();
        }

        public async Task<ResponseServices<User>> getUserById(int id)
        {
            var response = new ResponseServices<User>();
            try
            {
                var exisUser = await userRepo.getById(id);
                if (exisUser == null)
                {
                    response.data = null;
                    response.message = "Id not found";
                    response.status = false;

                    return response;
                }

                response.data = exisUser;
                response.message = "User fetched successfully";
                response.status = true;

                return response;
            }
            catch (Exception e)
            {
                response.data = new User();
                response.message = "User not exist or user is deleted";
                response.status = false;
                return response;
            }
        }

        public async Task<ResponseServices<User>> softDelete(int id)
        {
            var response = new ResponseServices<User>();
            try
            {
                var existUser = await userRepo.deleteUser(id);
                response.data = existUser;
                response.message = "User added successfully";
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.data = new User();
                response.message = "User does't exist or User is already deleted";
                response.status = false;
                return response;
            }

        }

        public async Task<ResponseServices<UpdateUserDTO>> updateUser(int id, UpdateUserDTO userDTO)
        {
            var response = new ResponseServices<UpdateUserDTO>();
            try
            {
                var newUser = new User
                {
                    Username = userDTO.Username,
                    Email = userDTO.Email,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    MobileNumber = userDTO.MobileNumber,
                    EmergencyMobileNumber = userDTO.EmergencyMobileNumber,
                    Role = userDTO.Role,
                    Gender = userDTO.Gender,
                    IsActive = userDTO.IsActive,
                };

                var result = await userRepo.updateUser(id, newUser);

                var updatedUser = new UpdateUserDTO
                {
                    Username = result.Username,
                    Email = result.Email,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    MobileNumber = result.MobileNumber,
                    EmergencyMobileNumber = result.EmergencyMobileNumber,
                    Role = result.Role,
                    Gender = result.Gender,
                    IsActive = result.IsActive,
                };

                response.data = updatedUser;
                response.message = "Success";
                response.status = true;

                return response;

            }
            catch (Exception e)
            {
                response.data = new UpdateUserDTO();
                response.message = "check service layer";
                response.status = false;

                return response;
            }
        }
    }
}