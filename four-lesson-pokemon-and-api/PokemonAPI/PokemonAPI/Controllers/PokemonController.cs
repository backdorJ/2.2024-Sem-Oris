using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Requests.GetPokeByFilter;
using PokemonAPI.Core.Requests.GetPokeByName;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeService _pokeService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="pokeService">Сервис для работы с покемонами</param>
    public PokemonController(IPokeService pokeService)
        => _pokeService = pokeService;

    /// <summary>
    /// Получить покемонов по фильтру
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Отфильтрованные покемоны</returns>
    [HttpGet]
    public async Task<GetPokeByFilterResponse> GetPokeByFilter(
        [FromQuery] GetPokeByFilterRequest request,
        CancellationToken cancellationToken)
    {
        var requestForApi = request == null
            ? new GetPokeByFilterRequest()
            : new GetPokeByFilterRequest(request);

        return await _pokeService.GetPokeByFilterAsync(requestForApi, cancellationToken);
    }

    /// <summary>
    /// Получить информацию по покемону
    /// </summary>
    /// <param name="pokeName">Имя покемона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Покемон</returns>
    [HttpGet("{pokeName}")]
    public async Task<GetPokeByNameResponse> GetPokeByName(
        [FromRoute] string pokeName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(pokeName))
            throw new ApplicationException("Не отправлено имя покемона");

        return await _pokeService.GetPokeByNameAsync(pokeName, cancellationToken);
    }
}