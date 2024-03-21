using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Services;

namespace PokemonAPI.Core;

/// <summary>
/// Вход для Core
/// </summary>
public static class Entry
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));

        serviceCollection.AddAutoMapper(typeof(Entry));
        serviceCollection.AddHttpClient();
        serviceCollection.AddLogging();
        serviceCollection.AddScoped<IDbSeeder, DbSeeder>();
        serviceCollection.AddScoped<IPokeService, PokeApiService>();
        
        return serviceCollection;
    }
}