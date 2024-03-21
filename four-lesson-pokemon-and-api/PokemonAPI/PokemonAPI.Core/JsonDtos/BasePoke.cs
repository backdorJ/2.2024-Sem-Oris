using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

public class BasePoke
{
    /// <summary>
    /// Имя для сида
    /// </summary>
    [JsonProperty("name")]
    public string PokeName { get; set; } = default!;

    /// <summary>
    /// URL для сида
    /// </summary>
    [JsonProperty("url")]
    public string PokeInfoURL { get; set; } = default!;
}