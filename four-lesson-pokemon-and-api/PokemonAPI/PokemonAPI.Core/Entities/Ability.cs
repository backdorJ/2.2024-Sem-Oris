namespace PokemonAPI.Core.Entities;

/// <summary>
/// Сущность способность
/// </summary>
public class Ability
{
    /// <summary>
    /// ИД сущности
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Назавние способности
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Покемоны
    /// </summary>
    public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}