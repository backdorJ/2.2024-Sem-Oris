using PokemonAPI.Paths;
using PokemonAPI.Services;

namespace PokemonAPI.Tests.Requests.PokemonsGetByIdOrName;

[TestClass]
public class PokemonsGetByIdOrNameResponseTest
{
    private static readonly HttpClient HttpClient = new();
    
    private readonly IPokeApiService _pokeApiService;

    /// <summary>
    /// Конструктор
    /// </summary>
    public PokemonsGetByIdOrNameResponseTest()
        => _pokeApiService = new PokeApiService(HttpClient);

    /// <summary>
    /// Обработчик должен вернуть полную информацию покемона по имени
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnPokeByName()
    {
        var placeholder = "bulbasaur";

        var response = await _pokeApiService
            .GetPokeDataByIdOrNameAsync(
                placeholder: placeholder,
                url: BasePathRequests.UrlPokemon);
        
        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Name);
        Assert.IsNotNull(response.Abilities);
        Assert.IsNotNull(response.Id);
        Assert.IsNotNull(response.Sprites);
        
        Assert.AreEqual(placeholder, response.Name);
    }

    /// <summary>
    /// Обработчик должен вернуть информацию о покемоне по ИД
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnPokeById()
    {
        var placeholder = "1";

        var response = await _pokeApiService
            .GetPokeDataByIdOrNameAsync(
                placeholder: placeholder,
                url: BasePathRequests.UrlPokemon);

        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Name);
        Assert.IsNotNull(response.Abilities);
        Assert.IsNotNull(response.Id);
        Assert.IsNotNull(response.Sprites);

        Assert.AreEqual(placeholder, response.Id.ToString());
    }
}