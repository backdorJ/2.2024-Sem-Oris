namespace PokemonAPI.Core.Entities;

/// <summary>
/// Сущности тип
/// </summary>
public class Type
{
    /// <summary>
    /// ИД сущности
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название типа
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Покемоны
    /// </summary>
    public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}