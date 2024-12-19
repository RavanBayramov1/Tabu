using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;

namespace Tabu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(TabuDbContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

}
