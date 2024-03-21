using Newtonsoft.Json;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Обверка для <see cref="Ability"/>
/// </summary>
public class Abilities
{
    /// <summary>
    /// Способности
    /// </summary>
    public AbilityDto? Ability { get; set; }
}