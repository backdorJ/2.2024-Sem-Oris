using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

/// <summary>
/// Для сида
/// </summary>
public class Poke
{
    /// <summary>
    /// Покемоны
    /// </summary>
    [JsonProperty("results")]
    public List<BasePoke> Pokes { get; set; }
}