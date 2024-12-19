using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements;

public class LanguageService(TabuDbContext _context, IMapper _mapper) : ILanguageService
{
    public IEnumerable<LanguageGetDto> GetAsync()
    {
        var data = _context.Languages.ToList();
        var lang = data.Select(x => _mapper.Map<LanguageGetDto>(x)).ToList();
        return lang;
    }
    public async Task CreateAsync(LanguageCreateDto dto)
    {
        var lang = _mapper.Map<Language>(dto);
        await _context.AddAsync(lang);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(string code,LanguageUpdateDto dto)
    {
        var lang = _mapper.Map<Language>(dto);
        var data = await _context.Languages.Where(x => x.Code == code).FirstOrDefaultAsync();
        data.Code = dto.Code;
        data.Name = dto.Name;
        data.Icon = dto.IconUrl;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(string code)
    {
        var data = await _context.Languages.Where(x => x.Code == code).FirstOrDefaultAsync();
        _context.Languages.Remove(data);
        await _context.SaveChangesAsync();
    }
}
