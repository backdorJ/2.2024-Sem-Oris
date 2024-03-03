namespace PokemonAPI.Modules.Requests.PokemonsGetByFilter;

/// <summary>
/// Запрос на получение покемонов
/// </summary>
public class PokemonsGetByFilterRequest
{
    public PokemonsGetByFilterRequest(PokemonsGetByFilterRequest request)
    {
        Offset = request.Offset;
        Limit = request.Limit;
        Search = request.Search;
    }

    public PokemonsGetByFilterRequest()
    {
    }
    
    /// <summary>
    /// Сколько пропустить
    /// </summary>
    public int Offset { get; set;  }

    /// <summary>
    /// Сколько взять
    /// </summary>
    public int Limit { get; set; } = 20;

    /// <summary>
    /// Поиск
    /// </summary>
    public string? Search { get; set; }
}