using Application.Features.Commands.UpdateDevice;
using Application.Features.Interfaces;
using Domain.Entities;
using Domain.Entities.Pizza;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdatePizza
{
    public class UpdatePizzaHandler : IRequestHandler<UpdatePizzaCommand, Pizza>
    {
            public readonly IUnitOfWork _unitOfWork;

            public UpdatePizzaHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Pizza> Handle(UpdatePizzaCommand request, CancellationToken cancellationToken)
            {
                var created = await _unitOfWork.PizzaRepository.UpdatePizza(request.PizzaDto, request.Id);
                return created;
            }
        }
}
