using Application.Features.DTOs;
using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetAllUser
{
    public class GetAllUserHandler : IRequestHandler<UserGetAllQuery, IEnumerable<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<IEnumerable<User>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var users =  _unitOfWork.UserRepository.GetAllUsers().ToList();
            return Task.FromResult<IEnumerable<User>>(users);
        }
    }
}
