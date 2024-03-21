namespace PokemonAPI.Core.Abstractions;

/// <summary>
/// Сервис для добавления базовых данных
/// </summary>
public interface IDbSeeder
{
    public Task SeedAsync(CancellationToken cancellationToken);
}