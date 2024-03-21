using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Статистика
/// </summary>
public class Stats
{
    /// <summary>
    /// Базовая статистика
    /// </summary>
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }

    /// <summary>
    /// Информация о статистике
    /// </summary>
    [JsonProperty("stat")]
    public StatDto? Stat { get; set; }
}