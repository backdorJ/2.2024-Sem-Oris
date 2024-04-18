using TeamHost.Domain.Common;

namespace TeamHost.Application.Contracts.Games.GetAllGames;

/// <summary>
/// Элемент списка для <see cref="GetAllGamesResponse"/>
/// </summary>
public class GetAllGamesResponseItem
{
    /// <summary>
    /// ИД игры
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя игры
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Картинка игры
    /// </summary>
    public List<string?>? ImageUrl { get; set; }

    /// <summary>
    /// Краткое описание
    /// </summary>
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Рейтинг
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Первая фотка
    /// </summary>
    public string? MainImage { get; set; }

    /// <summary>
    /// Остальные фото
    /// </summary>
    public List<string?>? LastImages { get; set; }

    public List<string?>? Platforms { get; set; }

    /// <summary>
    /// Цена игры
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Категория игры
    /// </summary>
    public List<string>? Category { get; set; }
}