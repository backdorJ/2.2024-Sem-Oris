namespace PokemonAPI.Core.Requests.GetPokeByName;

public class GetPokeStatResponseItem
{
    /// <summary>
    /// Название статистики
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Значение
    /// </summary>
    public double Value { get; set; }

}