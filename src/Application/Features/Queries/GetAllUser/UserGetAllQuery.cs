using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetAllUser
{
    public record UserGetAllQuery(): IRequest<IEnumerable<User>>
    {
    }
}
