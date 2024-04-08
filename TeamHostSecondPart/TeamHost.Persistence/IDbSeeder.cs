namespace TeamHost.Persistence;

public interface IDbSeeder
{
    public Task SeedAsync(CancellationToken cancellationToken);
}