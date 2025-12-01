using Application.Features.DTOs;
using Application.Features.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TestAppDbContext _dbContext;

        public UserRepository(TestAppDbContext dbContext)
        {

            _dbContext = dbContext;
        }


        public async Task<UserDto> CreateUser(UserDto user)
        {
            var userToSave = new UserDto();

            try
            {
                var userData = new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = user.UserName,
                    UserPW = user.UserPW,
                    UserRole = user.UserRole,
                    DepartmentName = user.DepartmentName,
                    Email = user.Email,
                    Benefits = user.Benifits,
                    Age = user.Age,
                    EventTimeStamp = DateTime.UtcNow
                };

                _dbContext.Users.Add(userData);
                await _dbContext.SaveChangesAsync();
                Console.WriteLine("Data saved successfully.");
                return userToSave;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"A database update error occurred: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }

                throw;
            }
            catch (Exception ex)
            {
                // Catch any other general exceptions that might occur during DbContext operations
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                // Log the exception
                throw;
            }
        }

        public  IQueryable<User> GetAllUsers()
        {
            try
            {
                var res = _dbContext.Users.AsQueryable();
                return res;
            }
            catch (DbException ex)
            {
                Console.WriteLine($"An database error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetUserById(Guid UserId)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync<User>(user => UserId == user.UserId);
                if (user == null)
                {
                    throw new InvalidOperationException("User not found.");
                }
                return user;
            }
            catch (DbException ex)
            {
                Console.WriteLine($"An database error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }
        
            
          
        public async Task<User> RemoveUser(Guid UserId)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(UserId);
                if(user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    return user;
                }
                throw new InvalidOperationException("User not found.");
            }
            catch (DbException ex)
            {
                Console.WriteLine($"An database error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<User> UpdateUser([FromBody] UserDto userDto, Guid UserId)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(UserId);
                if (user != null)
                {
                    user.UserName = userDto.UserName;
                    user.UserPW = userDto.UserPW;
                    user.UserRole = userDto.UserRole;
                    user.DepartmentName = userDto.DepartmentName;
                    user.Email = userDto.Email;
                    user.Benefits = userDto.Benifits;
                    user.Age = userDto.Age;
                    user.EventTimeStamp = DateTime.UtcNow;
                    await _dbContext.SaveChangesAsync();
                    return user;
                }
                throw new InvalidOperationException("User not found.");
            }
            catch (DbException ex)
            {
                Console.WriteLine($"An database error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
