using Application.Features.Interfaces;
using Domain.Entities.Pizza;
using MediatR;

namespace Application.Features.Commands.RemovePizza
{
    public class RemovePizzaHandler : IRequestHandler<RemovePizzaCommand, Pizza>
    {

            private readonly IUnitOfWork _unitOfWork;
            public RemovePizzaHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Pizza> Handle(RemovePizzaCommand request, CancellationToken cancellationToken)
            {

                var res = await _unitOfWork.PizzaRepository.RemovePizza(request.Id);
                return res;
            }
    }
}
