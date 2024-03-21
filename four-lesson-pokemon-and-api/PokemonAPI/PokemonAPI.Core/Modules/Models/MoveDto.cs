using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Ходы покемона
/// </summary>
public class MoveDto
{
    [JsonProperty("move")]
    public MoveItem MoveItem { get; set; }
}