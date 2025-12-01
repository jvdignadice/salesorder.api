using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetUser
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(request.UserId);
            return user;
        }
    }
}
