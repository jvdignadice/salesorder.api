using Application.Features.Interfaces;
using MediatR;

namespace Application.Features.Commands.CreateDepartment
{
    public class DepartmentCommandHandler : IRequestHandler<DepartmentCommand, Domain.Entities.Department>
    {

        private readonly IUnitOfWork _unitOfWork;
        public DepartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Department> Handle(DepartmentCommand request, CancellationToken cancellationToken)
        {
            var res = new Domain.Entities.Department();
            var dept = request.deptDto;
            await _unitOfWork.DepartmentRepository.CreateDepartment(dept);
            return res;
        }
    }
}
