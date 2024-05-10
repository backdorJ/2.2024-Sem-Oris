using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TeamHost.Persistence.Context;

/// <summary>
/// Скрипт для накатывания миграций
/// </summary>
public class Migrator
{
    private readonly EfContext _efContext;
    private readonly ILogger<Migrator> _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="efContext">Контекст БД</param>
    /// <param name="logger">Логгер</param>
    public Migrator(EfContext efContext, ILogger<Migrator> logger)
    {
        _efContext = efContext;
        _logger = logger;
    }
    
    public async Task MigrateAsync()
    {
        try
        {
            var migrationId = Guid.NewGuid();
            _logger.LogInformation($"Started applying migration {migrationId}");
            await _efContext.Database.MigrateAsync();
            _logger.LogInformation($"End applying migration {migrationId}");
        }
        catch (Exception e)
        {
            _logger.LogCritical($"Apply migrations is field {e.Message}");
            throw;
        }
    }
}