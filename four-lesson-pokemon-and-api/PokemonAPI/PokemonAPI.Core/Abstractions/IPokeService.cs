using PokemonAPI.Core.Requests.GetPokeByFilter;
using PokemonAPI.Core.Requests.GetPokeByName;

namespace PokemonAPI.Core.Abstractions;

public interface IPokeService
{
    /// <summary>
    /// Метод для получения покемонов по фильтру
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<GetPokeByFilterResponse> GetPokeByFilterAsync(
        GetPokeByFilterRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Получить покемонов по имени
    /// </summary>
    /// <param name="pokeName">Имя покемона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<GetPokeByNameResponse> GetPokeByNameAsync(string pokeName, CancellationToken cancellationToken);
}