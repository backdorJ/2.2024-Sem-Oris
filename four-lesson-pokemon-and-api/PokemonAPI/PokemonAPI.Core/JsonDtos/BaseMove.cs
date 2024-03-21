using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

public class BaseMove
{
    /// <summary>
    /// Название движения
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
}