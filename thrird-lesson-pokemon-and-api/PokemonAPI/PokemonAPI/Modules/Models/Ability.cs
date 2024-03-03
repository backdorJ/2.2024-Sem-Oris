using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Способность
/// </summary>
public class Ability
{
    /// <summary>
    /// Назавние способности
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Строка запроса
    /// </summary>
    [JsonProperty("url")]
    public string? Url { get; set; }
}