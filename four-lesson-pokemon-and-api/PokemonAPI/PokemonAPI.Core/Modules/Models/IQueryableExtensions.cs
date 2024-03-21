using PokemonAPI.Core.Requests.GetPokeByFilter;

namespace PokemonAPI.Core.Modules.Models;

/// <summary>
/// Расширения для IQueryable
/// </summary>
public static class IQueryableExtensions
{
    public static IQueryable<T> SkipTake<T>(this IQueryable<T> query, GetPokeByFilterRequest request)
    {
        if (request.PageNumber <= 0 || request.PageSize <= 0)
            return query;

        return query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);
    }
}