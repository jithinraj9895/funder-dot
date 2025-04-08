using jwt_funder.Core.Interfaces;
using jwt_funder.Models;
using jwt_funder.Models.Dto;
using jwt_funder.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace jwt_funder.Controllers;

[Authorize]
[ApiController]
public class AuthController(IFunderRepository funderRepository,JWTService jwtService) : ControllerBase
{

    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        List<User> users = await funderRepository.GetUsersAsync();
        return Ok(users);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto loginRequest)
    {
        User? user = await funderRepository.GetUserByUsername(loginRequest.Username);
        if (user != null)
        {
            if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                AuthenticationResponse res = new AuthenticationResponse();
                res.token = jwtService.GenerateToken(user.Username);
                return Ok(res);
            }
        }
        return Unauthorized();
    }
    
}