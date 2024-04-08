using Microsoft.Extensions.DependencyInjection;
using TeamHost.Application.Interfaces;
using TeamHost.Persistence.Context;

namespace TeamHost.Persistence.Extensions;

public static class Entry
{
    public static void AddPersistenceLayer(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));
        
        serviceCollection.AddDbContext<EfContext>();
        serviceCollection.AddScoped<IDbContext, EfContext>();
        serviceCollection.AddTransient<Migrator>();
        serviceCollection.AddScoped<IDbSeeder, DbSeeder>();
    }
}