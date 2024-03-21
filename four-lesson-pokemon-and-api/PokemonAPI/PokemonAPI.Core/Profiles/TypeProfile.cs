using System.Xml.Linq;
using AutoMapper;
using PokemonAPI.Core.Modules.Models;
using Type = PokemonAPI.Core.Entities.Type;

namespace PokemonAPI.Core.Profiles;

public class TypeProfile : Profile
{
    public TypeProfile()
    {
        CreateMap<Type, TypeDto>()
            .ForMember(x => x.Name, src => src.MapFrom(y => y.Name));
    }
}