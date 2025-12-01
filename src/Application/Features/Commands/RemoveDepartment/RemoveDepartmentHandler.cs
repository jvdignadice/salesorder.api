using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.RemoveDepartment
{
    public class RemoveDepartmentHandler : IRequestHandler<RemoveDepartmentCommand, Department>
    {

        private readonly IUnitOfWork _unitOfWork;
        public RemoveDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Department> Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.DepartmentRepository.RemoveDepartment(request.departmentId);
            return result;
        }   
    }
}
