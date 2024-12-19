using Tabu.DTOs.Languages;

namespace Tabu.Services.Abstracts;

public interface ILanguageService
{
    IEnumerable<LanguageGetDto> GetAsync();
    Task CreateAsync(LanguageCreateDto dto);
    Task UpdateAsync(string code,LanguageUpdateDto dto);
    Task DeleteAsync(string code);
}
