using TeamHost.Domain.Entities;

namespace TeamHost.Application.Contracts.Games.GetAllGames;

/// <summary>
/// Ответ на запрос всех игр
/// </summary>
public class GetAllGamesResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="entities">Сущности</param>
    /// <param name="totalCount">Общее кол-во</param>
    public GetAllGamesResponse(List<GetAllGamesResponseItem> entities, int totalCount)
    {
        Entities = entities;
        TotalCount = totalCount;
    }
    
    /// <summary>
    /// Список
    /// </summary>
    public List<GetAllGamesResponseItem> Entities { get; }

    /// <summary>
    /// Общее кол-во
    /// </summary>
    public int TotalCount { get; set; }
}