using Application.Features.Interfaces;
using Domain.Entities.SalesOrder;
using MediatR;

namespace Application.Features.Commands.RemoveOrderDetails
{
    public class RemoveOrderDetailsHandler : IRequestHandler<RemoveOrderDetailsCommand, OrderDetails>
    {

        private readonly IUnitOfWork _unitOfWork;
        public RemoveOrderDetailsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OrderDetails> Handle(RemoveOrderDetailsCommand request, CancellationToken cancellationToken)
        {

            var res = await _unitOfWork.OrderDetailsRepository.RemoveOrderDetails(request.Id);
            return res;
        }
    }
}
