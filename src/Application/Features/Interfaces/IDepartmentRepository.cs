using Application.Features.DTOs;
using Domain.Entities;

namespace Application.Features.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartment(DepartmentDtos deptDto);
        Task<Department> UpdateDepartment(DepartmentDtos deptDto, Guid id);
        Task<Department> RemoveDepartment(Guid id);
        Task<List<Department>> GetAllDepartment();
    }
}
