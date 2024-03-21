namespace PokemonAPI.Core.Entities;

/// <summary>
/// Сущность статистики покемона
/// </summary>
public class Stat
{
    /// <summary>
    /// Ид статистики
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название статистики
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Значение
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// ИД покемона
    /// </summary>
    public Guid PokemonId { get; set; }

    /// <summary>
    /// Покемон
    /// </summary>
    public Pokemon? Poke { get; set; }
}