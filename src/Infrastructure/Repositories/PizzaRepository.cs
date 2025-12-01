using Application.Features.DTOs;
using Application.Features.Interfaces;
using Application.Features.Queries.GetAllPizza;
using Azure.Core;
using Domain.Entities;
using Domain.Entities.Pizza;
using Infrastructure.Persistence;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {

        private readonly TestAppDbContext _dbContext;

        public PizzaRepository(TestAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PagedResult<Pizza>> GetAllPizza(GetAllPizzaQuery request)
        {
            var skip = (request.PageNumber - 1) * request.PageSize;

            var pizza = _dbContext.Pizza.Skip(skip)
                                   .Take(request.PageSize)
                                   .ToList();



            

            return new PagedResult<Pizza>
            {
                Items = pizza,
                TotalCount = 0,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

        }

        public async Task<Pizza> UpdatePizza(PizzaDto piz, int Id)
        {
            var pizza = await _dbContext.Pizza.FindAsync(Id);

            pizza.pizza_id = piz.pizza_id;
            pizza.pizza_type_id = piz.pizza_type_id;
            pizza.size = piz.size;
            pizza.price = piz.price;


            await _dbContext.SaveChangesAsync();
            return pizza;
        }

        public async Task<Pizza> RemovePizza(int Id)
        {
            var pizza = await _dbContext.Pizza.FindAsync(Id);

            if (pizza != null)
            {
                _dbContext.Pizza.Remove(pizza);
                await _dbContext.SaveChangesAsync();
            }
            return pizza;
        }
    }
}
