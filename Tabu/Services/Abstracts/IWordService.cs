using Tabu.DTOs.Languages;
using Tabu.DTOs.Words;

namespace Tabu.Services.Abstracts;

public interface IWordService 
{
    Task<IEnumerable<WordGetDto>> GetAllAsync();
    Task CreateAsync(WordCreateDto dto);
    Task UpdateAsync(int id, WordUpdateDto dto);
    Task DeleteAsync(int id);

}
