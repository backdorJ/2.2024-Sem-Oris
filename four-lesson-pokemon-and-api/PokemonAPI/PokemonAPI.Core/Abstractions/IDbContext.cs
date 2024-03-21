using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Entities;
using Type = PokemonAPI.Core.Entities.Type;

namespace PokemonAPI.Core.Abstractions;

/// <summary>
/// Контекст БД
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Способности
    /// </summary>
    DbSet<Ability> Abilities { get; set; }
    
    /// <summary>
    /// Вес, рост
    /// </summary>
    DbSet<Breeding> Breeding { get; set; }
    
    /// <summary>
    /// Движения
    /// </summary>
    DbSet<Move> Moves { get; set; }
    
    /// <summary>
    /// Покемоны
    /// </summary>
    DbSet<Pokemon> Pokemons { get; set; }
    
    /// <summary>
    /// Статистика
    /// </summary>
    DbSet<Stat> Stats { get; set; }
    
    /// <summary>
    /// Типы
    /// </summary>
    DbSet<Type> Types { get; set; }

    /// <summary>
    /// Сохранение
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}