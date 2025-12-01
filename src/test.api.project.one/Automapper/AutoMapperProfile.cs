using Application.Features.DTOs;
using AutoMapper;
using Domain.Entities;

namespace test.api.project.one.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
