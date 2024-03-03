using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Элмемент для <see cref="Move"/>
/// </summary>
public class MoveItem
{
    /// <summary>
    /// Название хода
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Адрес на api
    /// </summary>
    [JsonProperty("url")]
    public string? Url { get; set; }
}