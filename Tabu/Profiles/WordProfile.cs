using AutoMapper;
using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.Profiles;

public class WordProfile : Profile
{
    public WordProfile()
    {
        CreateMap<Word,WordGetDto>();
        CreateMap<WordCreateDto, Word>();
        CreateMap<WordUpdateDto, Word>();
    }
}
