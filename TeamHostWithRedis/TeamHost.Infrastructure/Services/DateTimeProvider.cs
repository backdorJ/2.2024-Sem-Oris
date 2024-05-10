using TeamHost.Application.Interfaces;

namespace TeamHost.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc />
    public DateTime CurrentDate => DateTime.UtcNow;
}