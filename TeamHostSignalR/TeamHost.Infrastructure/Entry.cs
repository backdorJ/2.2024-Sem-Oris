using Microsoft.Extensions.DependencyInjection;
using TeamHost.Application.Interfaces;
using TeamHost.Infrastructure.Services;

namespace TeamHost.Infrastructure;

public static class Entry
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddScoped<IUserContext, UserContext>();
    }
}