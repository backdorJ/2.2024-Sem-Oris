using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

public class JsonAbility
{
    /// <summary>
    /// Способности
    /// </summary>
    [JsonProperty("results")]
    public List<BaseAbility> Abilities { get; set; } = default!;
}