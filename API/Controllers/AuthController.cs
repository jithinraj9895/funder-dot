using jwt_funder.Core.Interfaces;
using jwt_funder.Models;
using Microsoft.AspNetCore.Mvc;

namespace jwt_funder.Controllers;

[Route("/api")]
[ApiController]
public class AuthController(IFunderRepository funderRepository) : ControllerBase
{
    

    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        List<User> users = await funderRepository.GetUsersAsync();
        return Ok(users);
    }
    
}