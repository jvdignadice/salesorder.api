
//using Application.Features.Commands.CreateUser;
//using Application.Features.DTOs;
//using Application.Features.Queries.GetAllUser;
//using Application.Features.Queries.GetUser;
//using Domain.Entities;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace test.api.project.one.Controllers
//{

//    [ApiController]
//    //[Authorize(Policy = "AdminOnly")]
//    [Route("api/v1/[controller]")]
//    public class UserController : ControllerBase
//    {
//        private readonly ILogger<UserController> _logger;
//        private readonly IMediator _mediator;
//        public UserController(ILogger<UserController> logger, IMediator mediator)
//        {
//            _logger = logger;
//            _mediator = mediator;

//        }

//        [HttpPost("CreateUser")]
//        public async Task<UserDto> CreateUser([FromBody] UserDto user)
//        {
//            if (user == null)
//                throw new ArgumentNullException(nameof(user));
//            var command = new CreateUserCommand(user);
//            var result = await _mediator.Send(command);
//            return user;
//        }



//        [HttpGet("GetAllUser")]
//        public async Task<IActionResult> GetAllUser()
//        {
//            var result = await _mediator.Send(new UserGetAllQuery());
//            return Ok(result);
//        }

//        [HttpGet("GetUserById")]
//        public async Task<User> GetUserById(Guid id)
//        {
//            var result = await _mediator.Send(new GetUserByIdQuery(id));
//            return result;
//        }

//        [HttpDelete("RemoveUser")]
//        public async Task<User> RemoveUser(Guid id)
//        {
//            var result = await _mediator.Send(new GetUserByIdQuery(id));
//            return result;
//        }

//        [HttpPut("UpdateUser")]
//        public async Task<User> UpdateUser([FromBody]UserDto userDto,Guid id)
//        {
//            var result = await _mediator.Send(new GetUserByIdQuery(id));
//            return result;
//        }


//    }
//}
