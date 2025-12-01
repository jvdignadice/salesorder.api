using Application.Features.Commands.RemoveDevice;
using Application.Features.Commands.RemovePizza;
using Application.Features.Commands.UpdateDevice;
using Application.Features.Commands.UpdatePizza;
using Application.Features.DTOs;
using Application.Features.Queries.GetAllDevice;
using Application.Features.Queries.GetAllPizza;
using Domain.Entities;
using Domain.Entities.Pizza;
using Infrastructure.Persistence;
using Infrastructure.Services.CsvReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace test.api.project.one.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PizzaTypesController : Controller
    {
        private readonly MediatR.IMediator _mediator;
        private readonly ILogger<PizzaTypesController> _logger;
        public PizzaTypesController(MediatR.IMediator mediator, ILogger<PizzaTypesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetAllPizza")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllPizzaQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("UpdatePizza")]
        public async Task<Pizza> UpdateDevice([FromBody] PizzaDto pizzaDto, int pizzaId)
        {
            if (pizzaId == null)
                throw new ArgumentNullException(nameof(pizzaId));
            var command = new UpdatePizzaCommand(pizzaDto, pizzaId);
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete("RemovePizza")]
        public async Task<PizzaDto> RemoveDevice([FromQuery] int pizzaId)
        {
            if (pizzaId == null)
                throw new ArgumentNullException(nameof(pizzaId));
            var command = new RemovePizzaCommand(pizzaId);
            var result = await _mediator.Send(command);
            return new PizzaDto();
        }
    }
}
