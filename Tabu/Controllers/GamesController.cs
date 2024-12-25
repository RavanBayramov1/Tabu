using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Games;
using Tabu.ExternalServices.Abstracts;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IGameService _service,ICacheService _cache) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(GameCreateDto dto)
    {
        return Ok(await _service.AddAsync(dto));
    }
    [HttpPost("Start/{id}")]
    public async Task<IActionResult> Start(Guid id)
    {
        await _service.StartAsync(id);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetGameData(Guid id)
    {
        return Ok(await _service.GetCurrentStatus(id));
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> Get(string key)
    {
        return Ok(await _cache.GetAsync<string>(key));
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> Set(string key,string value)
    {
        await _cache.SetAsync(key, value);
        return Ok();
    }
}
