using Application.Features.Commands.RemoveOrderDetails;
using Application.Features.Commands.RemovePizza;
using Application.Features.Commands.UpdateOrderDetails;
using Application.Features.Commands.UpdatePizza;
using Application.Features.DTOs;
using Application.Features.Queries.GetAllPizza;
using Application.Features.Queries.GetOrderDetails;
using Domain.Entities.Pizza;
using Domain.Entities.SalesOrder;
using Infrastructure.Services.CsvReader;
using Microsoft.AspNetCore.Mvc;

namespace test.api.project.one.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersDetailController: ControllerBase
    {

        private readonly MediatR.IMediator _mediator;
        private readonly ILogger<OrdersDetailController> _logger;
        public OrdersDetailController(MediatR.IMediator mediator, ILogger<OrdersDetailController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllOrderDetailsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("UpdateOrder")]
        public async Task<OrderDetails> UpdateOrder([FromBody] OrdersDetailDto ordersDetailDto, int Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));
            var command = new UpdateOrderDetailsCommand(ordersDetailDto, Id);
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete("RemoveOrder")]
        public async Task<OrdersDetailDto> RemoveOrder([FromQuery] int Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));
            var command = new RemoveOrderDetailsCommand(Id);
            var result = await _mediator.Send(command);
            return new OrdersDetailDto();
        }
    }
}
