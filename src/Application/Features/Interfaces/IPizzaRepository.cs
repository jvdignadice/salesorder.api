using Application.Features.DTOs;
using Application.Features.Queries.GetAllPizza;
using Domain.Entities.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces
{
    public interface IPizzaRepository
    {
        Task<PagedResult<Pizza>> GetAllPizza(GetAllPizzaQuery request);

        Task<Pizza> UpdatePizza(PizzaDto piz, int Id);

        Task<Pizza> RemovePizza(int Id);
    }
}
