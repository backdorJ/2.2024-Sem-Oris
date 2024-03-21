namespace PokemonAPI.Core.Entities;

/// <summary>
/// Сущность разведения
/// </summary>
public class Breeding
{
    /// <summary>
    /// Ид сущности
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Рост
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Сущность покемон
    /// </summary>
    public Pokemon Pokemon { get; set; } = default!;

    /// <summary>
    /// ИД покемона
    /// </summary>
    public Guid PokemonId { get; set; }
}