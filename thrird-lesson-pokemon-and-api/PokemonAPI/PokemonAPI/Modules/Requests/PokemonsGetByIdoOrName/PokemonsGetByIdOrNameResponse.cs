using Newtonsoft.Json;
using PokemonAPI.Modules.Models;

namespace PokemonAPI.Modules.Requests.PokemonsGetByIdoOrName;

/// <summary>
/// Ответ на получение покемона по ИД
/// </summary>
public class PokemonsGetByIdOrNameResponse
{
    /// <summary>
    /// Кол-во опыта
    /// </summary>
    [JsonProperty("base_experience")]
    public int? BaseExperience { get; set; }

    /// <summary>
    /// Высота
    /// </summary>
    [JsonProperty("height")]
    public double? Height { get; set; }

    /// <summary>
    /// Ширина
    /// </summary>
    [JsonProperty("weight")]
    public double? Weight { get; set; }

    /// <summary>   
    /// ИД сущности
    /// </summary>
    [JsonProperty("id")]
    public int? Id { get; set; }

    /// <summary>
    /// Имя покемона
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Порядок
    /// </summary>
    [JsonProperty("order")]
    public int Order { get; set; }

    /// <summary>
    /// Разновидности
    /// </summary>
    [JsonProperty("species")]
    public Species? Species { get; set; }

    /// <summary>
    /// Настройки для визуала для фронта
    /// </summary>
    [JsonProperty("sprites")]
    public Sprite? Sprites { get; set; }

    /// <summary>
    /// Статистика
    /// </summary>
    [JsonProperty("stats")]
    public List<Stats>? Stats { get; set; }

    /// <summary>
    /// Типы
    /// </summary>
    [JsonProperty("types")]
    public List<Types>? Types { get; set; }
    
    /// <summary>
    /// Список способностей
    /// </summary>
    [JsonProperty("abilities")]
    public List<Abilities>? Abilities { get; set; }
    
    /// <summary>
    /// Ходы
    /// </summary>
    [JsonProperty("moves")]
    public List<Move>? Moves { get; set; }
}