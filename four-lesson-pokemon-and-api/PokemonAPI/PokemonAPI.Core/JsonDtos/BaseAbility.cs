using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

public class BaseAbility
{
    /// <summary>
    /// Название способности
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = default!;
}