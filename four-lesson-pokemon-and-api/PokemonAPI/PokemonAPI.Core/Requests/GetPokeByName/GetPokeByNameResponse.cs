using PokemonAPI.Core.Entities;
using Type = System.Type;

namespace PokemonAPI.Core.Requests.GetPokeByName;

/// <summary>
/// Ответ на <see cref="GetPokeByNameRequest"/>
/// </summary>
public class GetPokeByNameResponse
{
    /// <summary>
    /// Имя покемона
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Картинка покемона 
    /// </summary>
    public string ImageUrl { get; set; } = default!;

    /// <summary>
    /// Число по порядку
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Рост, вес для покемона
    /// </summary>
    public GetPokeBreedingResponse? Breeding { get; set; }

    /// <summary>
    /// Способности
    /// </summary>
    public List<GetPokeAbilityResponseItem> Abilities { get; set; } = new();

    /// <summary>
    /// Движения
    /// </summary>
    public List<GetPokeMoveResponseItem> Moves { get; set; } = new();

    /// <summary>
    /// Типы
    /// </summary>
    public List<GetPokeTypeResponseItem> Types { get; set; } = new();
    
    /// <summary>
    /// Статистика
    /// </summary>
    public List<GetPokeStatResponseItem> Statistic { get; set; } = new();
}