using NotifierChanger.Model.Storage;
using StackExchange.Redis;

namespace NotifierChanger.Service.Storage;

public class RedisSessionStorage(IConnectionMultiplexer multiplexer) : ISessionStorage
{
    private readonly IDatabase _database = multiplexer.GetDatabase();
    
    public async Task<bool> isUserOnline(Guid userId)
    {
        var connections = await _database.StringGetAsync(UserConnsKey(userId));
        return connections.HasValue;
    }

    private string UserConnsKey(Guid userId) => $"user:{userId.ToString()}";
}