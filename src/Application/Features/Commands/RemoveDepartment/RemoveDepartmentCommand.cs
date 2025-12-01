using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.RemoveDepartment
{
    public record RemoveDepartmentCommand(Guid departmentId) : IRequest<Department>
    {
    }
}
