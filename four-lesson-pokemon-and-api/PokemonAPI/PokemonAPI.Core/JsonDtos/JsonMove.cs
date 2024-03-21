using Newtonsoft.Json;

namespace PokemonAPI.Core.JsonDtos;

public class JsonMove
{
    [JsonProperty("results")]
    public List<BaseMove>? Moves { get; set; }
}