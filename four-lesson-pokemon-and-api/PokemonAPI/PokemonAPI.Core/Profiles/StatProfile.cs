using AutoMapper;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Core.Profiles;

public class StatProfile : Profile
{
    public StatProfile()
    {
        CreateMap<Stat, StatDto>()
            .ForMember(x => x.Name, src => src.MapFrom(y => y.Name))
            .ForMember(x => x.Value, src => src.MapFrom(y => y.Value));
    }
}