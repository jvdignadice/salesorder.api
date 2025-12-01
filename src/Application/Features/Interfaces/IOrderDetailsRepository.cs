using Application.Features.DTOs;
using Application.Features.Queries.GetAllPizza;
using Application.Features.Queries.GetOrderDetails;
using Domain.Entities.Pizza;
using Domain.Entities.SalesOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces
{
    public interface IOrderDetailsRepository
    {
        Task<PagedResult<OrderDetails>> GetAllOrderDetails(GetAllOrderDetailsQuery request);
        Task<OrderDetails> UpdateOrderDetails(OrdersDetailDto oddto, int Id);
        Task<OrderDetails> RemoveOrderDetails(int Id);
    }
}
