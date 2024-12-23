using Tabu.DTOs.BannedWords;

namespace Tabu.Services.Abstracts;

public interface IBannedWordService
{
    Task UpdateAsync(int id, BannedWordUpdateDto dto);
}
