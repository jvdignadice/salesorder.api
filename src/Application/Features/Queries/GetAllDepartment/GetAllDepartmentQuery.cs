using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetAllDepartment
{
    public record GetAllDepartmentQuery: IRequest<List<Department>>
    {
    }
}
