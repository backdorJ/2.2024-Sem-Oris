namespace PokemonAPI.Core.Urls;

public class BaseUrls
{
    /// <summary>
    /// Путь на получение имени покемона
    /// </summary>
    public const string UrlPokemon = "https://pokeapi.co/api/v2/pokemon";

    /// <summary>
    /// Путь на получение типов
    /// </summary>
    public const string UrlTypes = "https://pokeapi.co/api/v2/type?limit=20";

    /// <summary>
    /// Путь для получения способностей
    /// </summary>
    public const string UrlAbilities = "https://pokeapi.co/api/v2/ability?limit=367";

    /// <summary>
    /// Путь для получения движений
    /// </summary>
    public const string UrlMoves = "https://pokeapi.co/api/v2/move?limit=937";
}