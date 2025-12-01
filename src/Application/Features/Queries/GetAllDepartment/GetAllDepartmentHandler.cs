using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetAllDepartment
{
    public class GetAllDepartmentHandler:   IRequestHandler<GetAllDepartmentQuery, List<Department>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await _unitOfWork.DepartmentRepository.GetAllDepartment();
            return departments;
        }
    }
}
