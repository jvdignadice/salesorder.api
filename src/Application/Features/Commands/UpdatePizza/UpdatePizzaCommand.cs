using Application.Features.DTOs;
using Domain.Entities.Pizza;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdatePizza
{
    public record UpdatePizzaCommand(PizzaDto PizzaDto, int Id) : IRequest<Pizza>
    {
    }
}
