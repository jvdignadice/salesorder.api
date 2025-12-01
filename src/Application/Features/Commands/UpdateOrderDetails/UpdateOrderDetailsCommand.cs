using Application.Features.DTOs;
using Domain.Entities.SalesOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdateOrderDetails
{
    public record UpdateOrderDetailsCommand(OrdersDetailDto Orders, int Id) : IRequest<OrderDetails>
    {
    }
}
