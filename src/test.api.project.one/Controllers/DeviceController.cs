//using Application.Features.Commands;
//using Application.Features.Commands.CreateDevice;
//using Application.Features.Commands.RemoveDevice;
//using Application.Features.Commands.UpdateDevice;
//using Application.Features.DTOs;
//using Application.Features.Queries;
//using Application.Features.Queries.GetAllDevice;
//using Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace test.api.project.one.Controllers
//{
//    [ApiController]
//    [Route("api/v1/[controller]")]

//    public class DeviceController : ControllerBase
//    {
//        private readonly MediatR.IMediator _mediator;
//        private readonly ILogger<DeviceController> _logger;
//        public DeviceController(MediatR.IMediator mediator, ILogger<DeviceController> logger)
//        {
//            _mediator = mediator;
//            _logger = logger;
//        }

//        [HttpPost("CreateDevice")]
//        public async Task<DeviceDto> CreateDevice([FromBody] DeviceDto deviceDto)
//        {
//            if (deviceDto == null)
//                throw new ArgumentNullException(nameof(deviceDto));
//            var command = new CreateDeviceCommand(deviceDto);
//            var result = await _mediator.Send(command);
//            return deviceDto;
//        }

//        [HttpGet("GetDevice")]
//        public async Task<List<Device>> GetDevice()
//        {
           
//            var command = new GetAllDeviceQuery();
//            var result = await _mediator.Send(command);
//            return result;
//        }

//        [HttpPut("UpdateDevice")]
//        public async Task<Device> UpdateDevice([FromBody] DeviceDto deviceDto, Guid deviceId)
//        {
//            if (deviceId == null)
//                throw new ArgumentNullException(nameof(deviceId));
//            var command = new UpdateDeviceCommand(deviceDto, deviceId);
//            var result = await _mediator.Send(command);
//            return result;
//        }

//        [HttpDelete("RemoveDevice")]
//        public async Task<DeviceDto> RemoveDevice([FromQuery] Guid deviceId)
//        {
//            if (deviceId == null)
//                throw new ArgumentNullException(nameof(deviceId));
//            var command = new RemoveDeviceCommand(deviceId);
//            var result = await _mediator.Send(command);
//            return new DeviceDto();
//        }
//    }
//}
