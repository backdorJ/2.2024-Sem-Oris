using AutoMapper;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Core.Profiles;

public class BreedingProfile : Profile
{
    public BreedingProfile()
    {
        CreateMap<Breeding, BreedingDto>()
            .ForMember(x => x.Height, src => src.MapFrom(y => y.Height))
            .ForMember(x => x.Weight, src => src.MapFrom(y => y.Weight));
    }
}