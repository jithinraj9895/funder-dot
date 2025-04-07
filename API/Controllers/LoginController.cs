using System.ComponentModel.DataAnnotations;
using jwt_funder.Models;
using jwt_funder.Models.Dto;
using jwt_funder.Services.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace jwt_funder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController(IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] UserDto user)
        {
            JWTService service = new JWTService(configuration);
            AuthenticationResponse response = new AuthenticationResponse();
            Console.WriteLine(user.Username);
            response.token = service.GenerateToken(user.Username);
            return Ok(response);
        }

        [HttpGet("test")]
        public IActionResult Get()
        {
            return Ok("controller works");
        }
    }
    
    
}
