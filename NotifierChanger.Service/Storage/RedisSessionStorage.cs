using NotifierChanger.Model.Storage;
using StackExchange.Redis;

namespace NotifierChanger.Service.Storage;

public class RedisSessionStorage(IConnectionMultiplexer multiplexer) : ISessionStorage
{
    private readonly IDatabase _database = multiplexer.GetDatabase();
    
    public async Task<bool> isUserOnline(Guid userId)
    {
        var connections = await GetUserIds(userId.ToString());
        return connections.Count > 0;
    }
    
    private async Task<List<string>> GetUserIds(string userId)
    {
        return (await _database.ListRangeAsync(UserConnsKey(userId), 0, -1))
            .Select(x => x.ToString())
            .ToList();
    }

    private string UserConnsKey(string userId) => $"user:{userId}";
}