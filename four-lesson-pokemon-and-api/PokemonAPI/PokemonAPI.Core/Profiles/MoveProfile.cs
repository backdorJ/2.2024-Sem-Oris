using AutoMapper;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Core.Profiles;

public class MoveProfile : Profile
{
    public MoveProfile()
    {
        CreateMap<Move, MoveItem>()
            .ForMember(x => x.Name, src => src.MapFrom(y => y.Name));
    }
}