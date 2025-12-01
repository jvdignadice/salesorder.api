using Domain.Entities;
using Domain.Entities.Pizza;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.RemovePizza
{

    public record RemovePizzaCommand(int Id) : IRequest<Pizza>
    {
    }
}
