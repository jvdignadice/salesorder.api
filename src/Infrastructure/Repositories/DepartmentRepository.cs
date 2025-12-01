using Application.Features.DTOs;
using Application.Features.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TestAppDbContext _dbContext;

        public DepartmentRepository(TestAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> CreateDepartment(DepartmentDtos deptDto)
        {
            try
            {
                var newDepartment = new Department
                {
                    DepartmentId = Guid.NewGuid(),
                    DepartmentName = deptDto.DepartmentName,
                    DepartmentDescription = deptDto.DepartmentDescription,
                    FloorNumber = deptDto.FloorNumber,
                };

                await _dbContext.Departments.AddAsync(newDepartment);
                await _dbContext.SaveChangesAsync();
                return newDepartment;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }

      
        public async Task<Department> UpdateDepartment(DepartmentDtos deptDto, Guid id)
        {
            try
            {

                var foundDept = await _dbContext.Departments.FindAsync(id);

                foundDept.DepartmentName = deptDto.DepartmentName;
                foundDept.DepartmentDescription = deptDto.DepartmentDescription;
                foundDept.FloorNumber = deptDto.FloorNumber;

                await _dbContext.SaveChangesAsync();
                return foundDept;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }

        public async Task<List<Department>> GetAllDepartment()
        {
            try
            {

                var departments = _dbContext.Departments.ToList();
                return departments;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }

        public async Task<Department> RemoveDepartment(Guid id)
        {
            try
            {

                var foundDept = await _dbContext.Departments.FindAsync(id);

                _dbContext.Departments.Remove(foundDept);
                await _dbContext.SaveChangesAsync();

                return foundDept;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }
    }
}
