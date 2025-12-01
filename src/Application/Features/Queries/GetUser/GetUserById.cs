using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetUser
{
    public record GetUserByIdQuery (Guid UserId) : IRequest<User>
    {
    }
}
