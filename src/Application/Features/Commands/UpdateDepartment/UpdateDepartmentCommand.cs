using Application.Features.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateDepartment
{
    public record UpdateDepartmentCommand(DepartmentDtos departmentDtos, Guid departmentId) : IRequest<Department>
    {
    }
}
