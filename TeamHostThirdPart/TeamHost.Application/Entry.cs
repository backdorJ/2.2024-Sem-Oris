using Microsoft.Extensions.DependencyInjection;

namespace TeamHost.Application;

public static class Entry
{
    public static void AddApplicationLayer(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));

        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Entry).Assembly));
    }
}