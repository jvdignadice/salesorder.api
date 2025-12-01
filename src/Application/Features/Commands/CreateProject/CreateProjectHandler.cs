using Application.Features.Interfaces;
using MediatR;

namespace Application.Features.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectsCommand, Domain.Entities.Project>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProjectHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Project> Handle(CreateProjectsCommand request, CancellationToken cancellationToken)
        {
            var res = new Domain.Entities.Project();
            //var project = request.projectDto;
            //await _unitOfWork.ProjectRepository.CreateProject(project);
            return res;
        }
    }
}
