using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Покемон
/// </summary>
public class PokemonDto
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
    public string ImageUrl { get; set; } = default!;
}