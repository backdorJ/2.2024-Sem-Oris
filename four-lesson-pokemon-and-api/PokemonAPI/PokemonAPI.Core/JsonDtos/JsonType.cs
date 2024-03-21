using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

public class JsonType
{
    /// <summary>
    /// Типы
    /// </summary>
    [JsonProperty("results")]
    public List<BaseType> Types { get; set; } = default!;
}