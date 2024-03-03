using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Информация о чем статистика
/// </summary>
public class Stat
{
    /// <summary>
    /// Название статистики (hp, attack, etc)
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
}