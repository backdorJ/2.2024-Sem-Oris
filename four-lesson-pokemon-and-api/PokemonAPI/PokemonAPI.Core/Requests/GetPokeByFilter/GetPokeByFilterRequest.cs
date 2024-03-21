using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Core.Requests.GetPokeByFilter;

/// <summary>
/// Запрос на получение покемонов по фильтру
/// </summary>
public class GetPokeByFilterRequest
{
    private int _pageNumber;
    private int _pageSize;
    
    public GetPokeByFilterRequest(GetPokeByFilterRequest request)
    {
        Search = request.Search;
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
    }

    public GetPokeByFilterRequest()
    {
        _pageNumber = PaginationDefaults.PageNumber;
        _pageSize = PaginationDefaults.PageSize;
    }
    
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value > 0 ? value : PaginationDefaults.PageNumber;
    }

    /// <summary>
    /// Кол-во элементов на странице
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > 0 ? value : PaginationDefaults.PageSize;
    }
    
    /// <summary>
    /// Поиск
    /// </summary>
    public string? Search { get; set; }
}