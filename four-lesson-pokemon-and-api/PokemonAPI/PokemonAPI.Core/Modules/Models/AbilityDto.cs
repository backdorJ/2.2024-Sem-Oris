using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Способность
/// </summary>
public class AbilityDto
{
    /// <summary>
    /// Назавние способности
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
}