using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entities;
using Tabu.Exceptions.Game;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements;

public class GameService(TabuDbContext _context,IMapper _mapper) : IGameService
{
    public async Task<Guid> AddAsync(GameCreateDto dto)
    {
        var entity = _mapper.Map<Game>(dto);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task StartAsync(Guid id)
    {
        var entity = await _context.Games.FindAsync(id);
        if (entity is null) throw new GameAlreadyFinishedException();
        if (await _context.Games.AnyAsync(x=>x.Id == id)) throw new GameNotFoundException();
        if (entity.Score is not null) throw new Exception();
        
     }
    public async Task<Game> GetCurrentStatus(Guid id)
    {
        var entity = await _context.Games.FindAsync(id);
        if (entity is null) throw new GameNotFoundException();
        return entity;
    }


    //async Task<GameStatusDto> _getGameStatusAsync(Guid id)
    //{
    //    GameStatusDto status = await _cache.GetAsync<GameStatusDto>(id.ToString());
    //    if (status is null)
    //        throw new Exception();
    //    return (status);
    //}
}
