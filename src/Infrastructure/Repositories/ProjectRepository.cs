using Application.Features.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly TestAppDbContext _dbContext;
    }
}
