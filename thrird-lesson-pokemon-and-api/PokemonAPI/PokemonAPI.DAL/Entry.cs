using Microsoft.Extensions.DependencyInjection;

namespace PokemonAPI.DAL;

public static class Entry
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));

        serviceCollection.AddDbContext<EfContext>();

        return serviceCollection;
    }
}