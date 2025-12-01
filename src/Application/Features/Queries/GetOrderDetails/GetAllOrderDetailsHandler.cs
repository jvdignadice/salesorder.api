using Application.Features.DTOs;
using Domain.Entities.SalesOrder;
using MediatR;

namespace Application.Features.Queries.GetOrderDetails
{
    public class GetAllOrderDetailsHandler : IRequestHandler<GetAllOrderDetailsQuery, PagedResult<OrderDetails>>
    {
        private readonly Interfaces.IUnitOfWork _unitOfWork;

        public GetAllOrderDetailsHandler(Interfaces.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<OrderDetails>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.OrderDetailsRepository.GetAllOrderDetails(request);

            return query;
        }
    }

}
