using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Элмемент для <see cref="MoveDto"/>
/// </summary>
public class MoveItem
{
    /// <summary>
    /// Название хода
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
}