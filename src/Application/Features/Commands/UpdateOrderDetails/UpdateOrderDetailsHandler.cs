using Application.Features.Interfaces;
using Domain.Entities.SalesOrder;
using MediatR;

namespace Application.Features.Commands.UpdateOrderDetails
{
    public class UpdateOrderDetailsHandler : IRequestHandler<UpdateOrderDetailsCommand, OrderDetails>
    {
        public readonly IUnitOfWork _unitOfWork;

        public UpdateOrderDetailsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetails> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var created = await _unitOfWork.OrderDetailsRepository.UpdateOrderDetails(request.Orders, request.Id);
            return created;
        }
    }
}
