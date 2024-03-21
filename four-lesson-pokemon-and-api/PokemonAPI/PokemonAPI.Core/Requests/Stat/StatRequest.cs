namespace PokemonAPI.Core.Requests.Stat;

public class StatRequest
{
    /// <summary>
    /// Название статистики
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Число
    /// </summary>
    public double Value { get; set; }
}