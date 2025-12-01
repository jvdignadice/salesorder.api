using Domain.Entities;
using Domain.Entities.SalesOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.RemoveOrderDetails
{
    public record RemoveOrderDetailsCommand(int Id) : IRequest<OrderDetails>
    {
    }
}
