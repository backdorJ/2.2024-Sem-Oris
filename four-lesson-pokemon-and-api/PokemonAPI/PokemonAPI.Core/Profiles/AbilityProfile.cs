using AutoMapper;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Core.Profiles;

public class AbilityProfile : Profile
{
    public AbilityProfile()
    {
        CreateMap<Ability, AbilityDto>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
    }
}