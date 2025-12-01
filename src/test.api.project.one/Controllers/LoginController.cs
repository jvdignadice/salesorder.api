//using Infrastructure.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace test.api.project.one.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class LoginController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;
//        private readonly IGenerateToken _generateToken;

//        public LoginController(IConfiguration configuration, IGenerateToken generateToken)
//        {
//            _generateToken = generateToken;
//            _configuration = configuration;
//        }

//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginModel model)
//        {
//            var token =  _generateToken.GenerateJwtToken(model.Username);
//            return Ok(new { Token = token });
//        }

       
//    }

//    public class LoginModel
//    {
//        public string Username { get; set; }
//        public string Password { get; set; }
//    }
//}
