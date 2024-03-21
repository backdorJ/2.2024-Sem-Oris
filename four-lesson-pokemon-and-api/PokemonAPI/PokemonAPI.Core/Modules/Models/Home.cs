using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Ссылки для фоток
/// </summary>
public class Home
{
    /// <summary>
    /// Картинка покемона для фронта
    /// </summary>
    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
}