using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Информация о чем статистика
/// </summary>
public class StatDto
{
    /// <summary>
    /// Название статистики (hp, attack, etc)
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Число
    /// </summary>
    public double Value { get; set; }
}