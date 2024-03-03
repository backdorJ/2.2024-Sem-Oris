using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PokemonAPI.FilterService;
using PokemonAPI.Modules.Requests.PokemonsGetByFilter;
using PokemonAPI.Modules.Requests.PokemonsGetByIdoOrName;

namespace PokemonAPI.Services;

/// <summary>
/// Сервис для взаимодействия с другим API
/// </summary>
public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _httpClient;

    private readonly IDistributedCache _distributedCache;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="httpClient">Http-клиент</param>
    /// <param name="distributedCache">Сервис для работы с кешем</param>
    public PokeApiService(HttpClient httpClient, IDistributedCache distributedCache)
    {
        _httpClient = httpClient;
        _distributedCache = distributedCache;
    }

    /// <inheritdoc />
    public async Task<PokemonsGetByFilterResponse> GetPokeDataAsync(
        PokemonsGetByFilterRequest request,
        string url,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));
        
        using var response = await _httpClient.GetAsync(
            $"{url}?limit={request.Limit}&offset={request.Offset}",
            cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            throw new ArgumentException("Что-то пошло не так");
        
        var pokeJson = await response.Content.ReadAsStringAsync(cancellationToken);
        var pokeData = JsonConvert.DeserializeObject<PokemonsGetByFilterResponse>(pokeJson)
            ?? throw new ArgumentNullException(nameof(pokeJson));

        pokeData = pokeData.FilterPokemons(request.Search);
        return pokeData;
    }

    /// <inheritdoc />
    public async Task<PokemonsGetByIdOrNameResponse> GetPokeDataByIdOrNameAsync(
        string placeholder,
        string url,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(placeholder))
            throw new ArgumentNullException(nameof(placeholder));

        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));

        var responseFromCache = await _distributedCache.GetStringAsync(placeholder, cancellationToken);

        if (!string.IsNullOrEmpty(responseFromCache))
            return JsonConvert.DeserializeObject<PokemonsGetByIdOrNameResponse>(responseFromCache)
                ?? throw new ArgumentNullException(nameof(responseFromCache));
            
        using var response = await _httpClient.GetAsync($"{url}/{placeholder.ToLower()}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new ArgumentException("Что-то пошло не так");

        var pokeJson = await response.Content.ReadAsStringAsync(cancellationToken);
        var pokeData = JsonConvert.DeserializeObject<PokemonsGetByIdOrNameResponse>(pokeJson) 
            ?? throw new ArgumentNullException(nameof(pokeJson));

        await _distributedCache.SetStringAsync(placeholder, pokeJson, cancellationToken);
            
        return pokeData;
    }
}