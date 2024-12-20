using AutoMapper;
using Tabu.DTOs.Languages;
using Tabu.Entities;

namespace Tabu.Profiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<Language, LanguageGetDto>()
            .ForMember(t => t.IconUrl, d => d.MapFrom(l => l.Icon));
        CreateMap<LanguageCreateDto,Language>()
            .ForMember(l => l.Icon,d => d.MapFrom(t => t.IconUrl));
        CreateMap<LanguageUpdateDto, Language>()
            .ForMember(l => l.Icon, d => d.MapFrom(t => t.IconUrl));
    }
}
