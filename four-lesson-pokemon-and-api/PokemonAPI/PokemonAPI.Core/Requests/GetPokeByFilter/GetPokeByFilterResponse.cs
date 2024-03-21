using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Core.Requests.GetPokeByFilter;

/// <summary>
/// Ответ для <see cref="GetPokeByFilterRequest"/>
/// </summary>
public class GetPokeByFilterResponse
{
    public GetPokeByFilterResponse(List<PokemonDto>? entities, int totalCount)
    {
        Entities = entities;
        TotalCount = totalCount;
    }
    
    /// <summary>
    /// Покемоны
    /// </summary>
    public List<PokemonDto>? Entities { get; set; }

    /// <summary>
    /// Общее кол-во
    /// </summary>
    public int TotalCount { get; set; }
}