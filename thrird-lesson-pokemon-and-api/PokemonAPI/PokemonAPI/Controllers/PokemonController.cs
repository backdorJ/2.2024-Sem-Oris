using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Modules.Requests.PokemonsGetByFilter;
using PokemonAPI.Modules.Requests.PokemonsGetByIdoOrName;
using PokemonAPI.Paths;
using PokemonAPI.Services;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeApiService _pokeApiService;
    private readonly ILogger<PokemonController> _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="pokeApiService">Сервис для взаимодействия со сторонним API</param>
    /// <param name="logger">Логгер для понимания, что происходит</param>
    public PokemonController(IPokeApiService pokeApiService, ILogger<PokemonController> logger)
    {
        _pokeApiService = pokeApiService;
        _logger = logger;
    }

    /// <summary>
    /// Получить покемонов по фильтру
    /// </summary>
    /// <returns>Покемоны</returns>
    [HttpGet]
    public async Task<PokemonsGetByFilterResponse> GetByFilters(
        [FromQuery] PokemonsGetByFilterRequest request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        _logger.LogInformation("Запрос ушел из метода GetByFilters");
        
        return await _pokeApiService.GetPokeDataAsync(
            request: request,
            url: BasePathRequests.UrlPokemon,
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Получить покемона по ИД или по имени
    /// </summary>
    /// <param name="placeholder">Имя покемона или ИД покемона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Покемон</returns>
    [HttpGet("{placeholder}")]
    public async Task<PokemonsGetByIdOrNameResponse> GetByIdOrName(
        string placeholder,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(placeholder))
            throw new ArgumentNullException(nameof(placeholder));
        
        _logger.LogInformation("Запрос ушел из метода GetByIdOrName");

        return await _pokeApiService.GetPokeDataByIdOrNameAsync(
            placeholder: placeholder,
            url: BasePathRequests.UrlPokemon,
            cancellationToken: cancellationToken);
    }
}