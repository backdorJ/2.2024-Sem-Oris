namespace PokemonAPI.Core.Entities;

/// <summary>
/// Сущность движений
/// </summary>
public class Move
{
    /// <summary>
    /// ИД сущности
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название движения
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Покемоны
    /// </summary>
    public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}