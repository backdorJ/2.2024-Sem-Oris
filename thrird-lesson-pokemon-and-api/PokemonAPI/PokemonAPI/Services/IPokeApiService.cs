using PokemonAPI.Modules.Requests.PokemonsGetByFilter;
using PokemonAPI.Modules.Requests.PokemonsGetByIdoOrName;

namespace PokemonAPI.Services;

/// <summary>
/// Сервис для работы с запрсоми со сторонним API
/// </summary>
public interface IPokeApiService
{
    /// <summary>
    /// Получить покемонов
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <param name="url">Сссылка на путь</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Покемоны</returns>
    public Task<PokemonsGetByFilterResponse> GetPokeDataAsync(
        PokemonsGetByFilterRequest request,
        string url,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить дополнительную информацию о покемоне
    /// </summary>
    /// <param name="placeholder">Имя или ИД</param>
    /// <param name="url">Путь</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Дополонительная информация о покемоне</returns>
    public Task<PokemonsGetByIdOrNameResponse> GetPokeDataByIdOrNameAsync(
        string placeholder,
        string url,
        CancellationToken cancellationToken = default);
}