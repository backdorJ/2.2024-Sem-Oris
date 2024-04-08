namespace TeamHost.Application.Extensions;

public static class DateTimeExtensions
{
    /// <summary>
    /// Конвертировать датус в нужный для PostgreSQL
    /// </summary>
    /// <param name="dateTime">Дата</param>
    /// <returns>Корректная дата</returns>
    public static DateTime? GetCorrectDateTime(this DateTime? dateTime)
        => dateTime?.SetKindUtc();
    
    private static DateTime SetKindUtc(this DateTime dateTime)
        => dateTime.Kind == DateTimeKind.Utc
            ? dateTime
            : DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
}