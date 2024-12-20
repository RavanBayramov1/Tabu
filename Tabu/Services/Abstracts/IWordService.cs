using Tabu.DTOs.Words;

namespace Tabu.Services.Abstracts;

public interface IWordService 
{
    Task<WordCreateDto> CreateAsync(WordCreateDto dto);
}
