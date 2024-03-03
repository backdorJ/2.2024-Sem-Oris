using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Тип
/// </summary>
public class Type
{
    /// <summary>
    /// Название типа
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
}