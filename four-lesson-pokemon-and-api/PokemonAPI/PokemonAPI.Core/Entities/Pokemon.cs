namespace PokemonAPI.Core.Entities;

/// <summary>
/// Сущность покемон
/// </summary>
public class Pokemon
{
    /// <summary>
    /// Ид покемона
    /// </summary>
    public Guid Id { get; set; }
    
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
    public Breeding? Breeding { get; set; }

    /// <summary>
    /// Способности
    /// </summary>
    public List<Ability> Abilities { get; set; } = new();

    /// <summary>
    /// Движения
    /// </summary>
    public List<Move> Moves { get; set; } = new();

    /// <summary>
    /// Типы
    /// </summary>
    public List<Type> Types { get; set; } = new();
    
    /// <summary>
    /// Статистика
    /// </summary>
    public List<Stat> Statistic { get; set; } = new();
}