using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateUser
{
    public class CreateUserHandler: IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var res = new User();
            var user = request.userDto;
            await _unitOfWork.UserRepository.CreateUser(user);
            return res;
        }
    }
}
