using Application.Features.DTOs;
using Domain.Entities.Pizza;
using MediatR;

namespace Application.Features.Queries.GetAllPizza
{
    public class GetAllPizzaHandler : IRequestHandler<GetAllPizzaQuery, PagedResult<Pizza>>
    {
        private readonly Interfaces.IUnitOfWork _unitOfWork;

        public GetAllPizzaHandler(Interfaces.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<Pizza>> Handle(GetAllPizzaQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.PizzaRepository.GetAllPizza(request); 

           return query;
        }
    }

}
