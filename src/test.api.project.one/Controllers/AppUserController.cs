//using Application.Features.DTOs;
//using Application.Features.Interfaces;
//using Domain.Entities;
//using Infrastructure.Persistence;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace test.api.project.one.Controllers
//{
    
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AppUserController : ControllerBase
//    {
//        private readonly IUserService _userService;
//        private readonly TestAppDbContext _context;

//        public AppUserController(IUserService userService, TestAppDbContext testAppDbContext)
//        {
//            _userService = userService;
//            _context = testAppDbContext;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] AppUserDto dto)
//        {
//            var token = await _userService.Authenticate(dto);
//            if (token == null) return Unauthorized();
//            return Ok(new { token });
//        }

//        [HttpPost("add-user")]
//        public async Task<IActionResult> AddUser([FromBody] AppUserDto dto)
//        {
//            var user = new AppUser
//            {
//                Username = dto.Username,
//                PasswordHash = dto.Password, // In production, hash the password
//            };
//            await _context.AppUsers.AddAsync(user);
//            await _context.SaveChangesAsync();
//            return Ok();
//        }


//        [HttpGet("admin")]
//        [Authorize(Roles = "admin")]
//        public IActionResult AdminEndpoint()
//        {
//            return Ok("Welcome Admin!");
//        } 

//        [HttpGet("user")]
//        [Authorize(Roles = "User,Admin")]
//        public IActionResult UserEndpoint() => Ok("Welcome User!");
//    }
//}
