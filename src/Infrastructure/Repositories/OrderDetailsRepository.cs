using Application.Features.DTOs;
using Application.Features.Interfaces;
using Application.Features.Queries.GetAllPizza;
using Application.Features.Queries.GetOrderDetails;
using Domain.Entities.Pizza;
using Domain.Entities.SalesOrder;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {

        private readonly TestAppDbContext _dbContext;

        public OrderDetailsRepository(TestAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PagedResult<OrderDetails>> GetAllOrderDetails(GetAllOrderDetailsQuery request)
        {
            var skip = (request.PageNumber - 1) * request.PageSize;

            var pizza = _dbContext.OrderDetails.Skip(skip)
                                   .Take(request.PageSize)
                                   .ToList();

            return new PagedResult<OrderDetails>
            {
                Items = pizza,
                TotalCount = 0,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

        }

        public async Task<OrderDetails> UpdateOrderDetails(OrdersDetailDto oddto, int Id)
        {
            var order = await _dbContext.OrderDetails.FindAsync(Id);

            order.pizza_id = oddto.pizza_id;
            order.quantity = oddto.quantity;
            order.order_id = oddto.order_id;


            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<OrderDetails> RemoveOrderDetails(int Id)
        {
            var order = await _dbContext.OrderDetails.FindAsync(Id);

            if (order != null)
            {
                _dbContext.OrderDetails.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
            return order;
        }
    }
}
