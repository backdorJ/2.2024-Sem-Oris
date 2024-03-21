using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Core.Abstractions;

namespace PokemonAPI.DAL.PostgreSQL;

/// <summary>
/// Входная точка для DAL уровня
/// </summary>
public static class Entry
{
    public static IServiceCollection AddPostgreSQLCore(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));

        serviceCollection.AddDbContext<EfContext>();
        serviceCollection.AddScoped<IDbContext, EfContext>();

        return serviceCollection;
    }
}