using jwt_funder.Core.Interfaces;
using jwt_funder.Models;
using jwt_funder.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_funder.Controllers;

[Authorize]
[ApiController]
public class IdeaController(IFunderRepository funderRepository) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("best")]
    public async Task<List<BestIdeasDto>> FindTop10Best()
    {
        return await funderRepository.GetTopIdeasAsync();
    }

    [HttpGet("ideas")]
    public async Task<List<Idea>> FindAllIdeas()
    {
        return await funderRepository.GetAllIdeasAsync();
    }
    
}