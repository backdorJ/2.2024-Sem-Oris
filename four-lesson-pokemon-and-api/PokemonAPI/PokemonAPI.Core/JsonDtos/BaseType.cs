using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

/// <summary>
/// Для JSON
/// </summary>
public class BaseType
{
    /// <summary>
    /// Имя типа
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
}