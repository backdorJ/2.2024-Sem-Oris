using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Сущность для обвертки над класса <see cref="Home"/>
/// </summary>
public class Other
{
    /// <summary>
    /// Картинки покемонов для фронта
    /// </summary>
    [JsonProperty("home")]
    public Home? Home { get; set; }
}