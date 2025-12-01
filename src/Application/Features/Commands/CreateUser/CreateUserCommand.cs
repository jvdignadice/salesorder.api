using Application.Features.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateUser
{
    public record CreateUserCommand(UserDto userDto) : IRequest<User>
    {
    }
}
