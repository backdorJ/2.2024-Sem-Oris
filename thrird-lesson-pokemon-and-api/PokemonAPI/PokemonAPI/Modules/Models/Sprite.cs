using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Спрайт не кола
/// </summary>
public class Sprite
{
    [JsonProperty("other")]
    public Other? Other { get; set; }
}