using Application.Features.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateProject
{
    public record CreateProjectsCommand(ProjectDto ProjectsDto): IRequest<Project>
    {
    }
}
