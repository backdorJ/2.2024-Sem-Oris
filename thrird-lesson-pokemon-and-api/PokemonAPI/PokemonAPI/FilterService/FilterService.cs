using PokemonAPI.Modules.Requests.PokemonsGetByFilter;

namespace PokemonAPI.FilterService;

/// <summary>
/// Сервис для фильтрации данных
/// </summary>
public static class FilterService
{
    /// <summary>
    /// Получить покемонов по фильтру
    /// </summary>
    /// <param name="pokemons">Покемоны</param>
    /// <param name="searchFilter">Строка фильтра</param>
    /// <returns>Отфильрованные данные</returns>
    public static PokemonsGetByFilterResponse FilterPokemons(
        this PokemonsGetByFilterResponse pokemons,
        string? searchFilter)
    {
        if (string.IsNullOrWhiteSpace(searchFilter))
            return pokemons;

        if (pokemons.Pokemons is null)
            return pokemons;

        var filteredData = pokemons.Pokemons
            .Where(x => x.Name.ToLower().Contains(searchFilter.ToLower()))
            .ToList();

        return new PokemonsGetByFilterResponse
        {
            Count = filteredData.Count,
            Next = null, // not filling required
            Previous = null, // not filling required
            Pokemons = filteredData,
        };
    }
}