using Microsoft.Extensions.Caching.Distributed;
using Moq;
using StackExchange.Redis;

namespace PokemonAPI.Tests;

public class UnitTestBase
{
    public Mock<IConnectionMultiplexer> MockMultiplexer { get; }

    public Mock<IDatabase> MockDatabase { get; }

    public Mock<IDistributedCache> MockIDistributedCache { get; set; }

    public UnitTestBase()
    {
        MockMultiplexer = new Mock<IConnectionMultiplexer>();
        MockDatabase = new Mock<IDatabase>();
        MockIDistributedCache = new Mock<IDistributedCache>();
        
        MockIDistributedCache
            .SetReturnsDefault("");

        MockMultiplexer
            .Setup(x => x.IsConnected)
            .Returns(false);
        
        MockMultiplexer
            .Setup(x => x.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
            .Returns(MockDatabase.Object);
    }
}