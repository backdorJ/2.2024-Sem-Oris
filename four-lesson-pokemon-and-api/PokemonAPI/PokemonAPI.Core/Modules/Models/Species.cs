using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Разновидность
/// </summary>
public class Species
{
    /// <summary>
    /// Имя покемона
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Адрес на другой api
    /// </summary>
    [JsonProperty("url")]
    public string? Url { get; set; }
}