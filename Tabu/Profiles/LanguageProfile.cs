﻿using AutoMapper;
using Tabu.DTOs.Languages;
using Tabu.Entities;

namespace Tabu.Profiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<LanguageCreateDto,Language>()
            .ForMember(l => l.Icon,d => d.MapFrom(t => t.IconUrl));
        CreateMap<Language, LanguageGetDto>();
        CreateMap<LanguageUpdateDto, Language>()
            .ForMember(l => l.Icon, d => d.MapFrom(t => t.IconUrl));
    }
}
