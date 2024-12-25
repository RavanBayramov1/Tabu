using AutoMapper;
using Tabu.DTOs.Games;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateDto, Game>()
                .ForMember(x=>x.Time , y=>y.MapFrom(z=>new TimeSpan(z.Seconds*10000000)))
                .ForMember(x => x.BannedWordCount, y => y.MapFrom(z => (int)z.GameLevel));
        }
    }
}
