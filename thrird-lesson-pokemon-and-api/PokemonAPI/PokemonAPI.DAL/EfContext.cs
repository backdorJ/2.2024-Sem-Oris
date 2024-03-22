using Microsoft.EntityFrameworkCore;

namespace PokemonAPI.DAL;

public class EfContext : DbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }
}