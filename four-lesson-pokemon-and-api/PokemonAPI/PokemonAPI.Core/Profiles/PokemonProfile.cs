using AutoMapper;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Core.Profiles;

public class PokemonProfile : Profile
{
    public PokemonProfile()
    {
        CreateMap<Pokemon, PokemonDto>()
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
            .ForMember(dest => dest.ImageUrl, src => src.MapFrom(x => x.ImageUrl));
    }
}