using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Тип
/// </summary>
public class TypeDto
{
    /// <summary>
    /// Название типа
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
}