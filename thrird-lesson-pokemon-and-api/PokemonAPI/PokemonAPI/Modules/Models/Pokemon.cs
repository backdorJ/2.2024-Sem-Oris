using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Покемон
/// </summary>
public class Pokemon
{
    /// <summary>
    /// Имя покемона
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Url на подробную инфу
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = default!;
}