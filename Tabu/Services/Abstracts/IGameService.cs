using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.Services.Abstracts;

public interface IGameService
{

    Task<Guid> AddAsync(GameCreateDto dto);
    Task StartAsync(Guid id);
    Task<Game> GetCurrentStatus(Guid id);
   
}
