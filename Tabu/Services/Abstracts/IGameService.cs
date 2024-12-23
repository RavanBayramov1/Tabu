using Tabu.DTOs.Games;

namespace Tabu.Services.Abstracts;

public interface IGameService
{
    Task AddAsync(GamesCreateDto dto);

}
