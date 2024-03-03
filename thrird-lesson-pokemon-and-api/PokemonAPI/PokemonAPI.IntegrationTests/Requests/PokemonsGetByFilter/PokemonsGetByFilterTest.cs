using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using PokemonAPI.Modules.Requests.PokemonsGetByFilter;
using PokemonAPI.Paths;
using PokemonAPI.Services;

namespace PokemonAPI.Tests.Requests.PokemonsGetByFilter;

[TestClass]
public class PokemonsGetByFilterTest : UnitTestBase
{
    private static readonly HttpClient HttpClient = new();
    
    private readonly IPokeApiService _pokeApiService;

    /// <summary>
    /// Конструктор
    /// </summary>
    public PokemonsGetByFilterTest()
        => _pokeApiService = new PokeApiService(HttpClient, MockIDistributedCache.Object);

    /// <summary>
    /// Обработчик должен вернуть покемона по поиску
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnPokeBySearch()
    {
        var request = new PokemonsGetByFilterRequest
        {
            Offset = 0,
            Limit = 1300,
            Search = "bulbasaur"
        };

        var response = await _pokeApiService
            .GetPokeDataAsync(
                request,
                $"{BasePathRequests.UrlPokemon}");
        
        Assert.IsNotNull(response);
        Assert.AreEqual(request.Search, response.Pokemons!.First().Name);
    }

    /// <summary>
    /// Обработчик должен вернуть конкретное кол-во покемонов
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnCountPoke()
    {
        var request = new PokemonsGetByFilterRequest
        {
            Offset = 0,
            Limit = 100,
            Search = null
        };

        var response = await _pokeApiService
            .GetPokeDataAsync(
                request: request,
                url: BasePathRequests.UrlPokemon);
        
        Assert.IsNotNull(response);
        Assert.AreEqual(request.Limit, response.Pokemons!.Count);
    }

    /// <summary>
    /// Обработчик должен вернуть покемонов, но пропустить n - кол-во
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnCountBeforeOffset()
    {
        var request = new PokemonsGetByFilterRequest
        {
            Offset = 100,
            Limit = 100,
            Search = null
        };

        var response = await _pokeApiService
            .GetPokeDataAsync(
                request: request,
                url: BasePathRequests.UrlPokemon);
        
        Assert.IsNotNull(response);
        Assert.AreEqual(request.Offset, response.Pokemons!.Count);
    }
}