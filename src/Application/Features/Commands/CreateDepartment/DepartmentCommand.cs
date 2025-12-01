using Application.Features.DTOs;
using MediatR;

namespace Application.Features.Commands.CreateDepartment
{
    public record DepartmentCommand(DepartmentDtos deptDto): IRequest<Domain.Entities.Department>
    {
    }
}
