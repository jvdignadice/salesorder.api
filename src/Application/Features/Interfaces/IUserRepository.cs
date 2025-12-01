using Application.Features.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> CreateUser(UserDto user);
        //Task<List<User>> GetAllUsers();
        IQueryable<User> GetAllUsers();
        Task<User> GetUserById(Guid UserId);
        Task<User> UpdateUser([FromBody] UserDto userDto, Guid UserId);
        Task<User> RemoveUser(Guid UserId);
    }
}
