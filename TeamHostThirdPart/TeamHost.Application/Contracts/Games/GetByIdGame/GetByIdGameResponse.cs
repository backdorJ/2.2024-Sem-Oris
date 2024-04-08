namespace TeamHost.Application.Contracts.Games.GetByIdGame;

/// <summary>
/// Ответ на запрос игры по ИД
/// </summary>
public class GetByIdGameResponse
{
    /// <summary>
    /// Название игры
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Главная фотка
    /// </summary>
    public string? MainImage { get; set; }

    /// <summary>
    /// Все фотки
    /// </summary>
    public List<string?> MediaFiles { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Рейтинг
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Дата релиза
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// Платформы
    /// </summary>
    public List<string?> Platforms { get; set; }

    /// <summary>
    /// Категории
    /// </summary>
    public List<string> Categories { get; set; }

    /// <summary>
    /// Компания
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
}