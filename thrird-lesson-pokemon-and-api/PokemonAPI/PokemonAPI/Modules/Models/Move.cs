using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Ходы покемона
/// </summary>
public class Move
{
    [JsonProperty("move")]
    public MoveItem MoveItem { get; set; }
}