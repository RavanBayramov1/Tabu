using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(ILanguageService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _service.GetAsync();
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> Post(LanguageCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Created();
    }
    [HttpPut]
    public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
    {
        await _service.UpdateAsync(code, dto);
        return Ok();
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(string code)
    {
        await _service.DeleteAsync(code);
        return Ok();
    }

}
