using Newtonsoft.Json;
using PokemonAPI.Modules.Models;

namespace PokemonAPI.Modules.Requests.PokemonsGetByFilter;

/// <summary>
/// Модель ответа на получение покемонов по фильтру
/// </summary>
public class PokemonsGetByFilterResponse
{
    /// <summary>
    /// Кол-во покемонов
    /// </summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    /// <summary>
    /// Стркоа запроса на след элементы ( не используется )
    /// </summary>
    [JsonProperty("next")]
    public string? Next { get; set; }

    /// <summary>
    /// Строка запроса на предыдущие элементы ( не используется )
    /// </summary>
    [JsonProperty("previous")]
    public string? Previous { get; set; }

    /// <summary>
    /// Покемоны
    /// </summary>
    [JsonProperty("results")]
    public List<Pokemon>? Pokemons { get; set; }
}