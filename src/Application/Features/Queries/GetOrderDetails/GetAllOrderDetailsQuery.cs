using Application.Features.DTOs;
using Domain.Entities.Pizza;
using Domain.Entities.SalesOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetOrderDetails
{
    public class GetAllOrderDetailsQuery : IRequest<PagedResult<OrderDetails>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
