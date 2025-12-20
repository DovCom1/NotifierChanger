using Microsoft.EntityFrameworkCore;
using NotifierChanger.Infrastructure;
using NotifierChanger.Model.Manager;
using NotifierChanger.Model.Request;
using NotifierChanger.Model.Service;
using NotifierChanger.Model.Storage;
using NotifierChanger.Service.Manager;
using NotifierChanger.Service.Service;
using NotifierChanger.Service.Storage;
using StackExchange.Redis;

namespace NotifierChanger.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionRedisString = configuration["RedisConnection:ConnectionString"]
                                 ?? throw new NullReferenceException("No connection string cache");
        var connectionPassword = configuration["RedisConnection:Password"] 
                                 ?? throw new NullReferenceException("No connection password");
        var connectionDatabase = configuration["PostgresConnection:DefaultConnection"]
                                 ?? throw new NullReferenceException("No postgresConnection");
        return services
            .AddOptions(configuration)
            .AddStorages(connectionRedisString, connectionPassword, connectionDatabase)
            .AddServices()
            .AddManagers()
            .AddHttpClientFactory();
    }

    private static IServiceCollection AddOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .Configure<RequestDomains>(configuration.GetSection("RequestDomains"));
    }

    private static IServiceCollection AddStorages(
        this IServiceCollection services, 
        string connectionString,
        string password,
        string connectionDatabase)
    {
        return services
            .AddSingleton<IConnectionMultiplexer>(_ =>
            {
                var options = ConfigurationOptions.Parse(connectionString);
                if (!string.IsNullOrWhiteSpace(connectionString)) options.Password = password;
                options.AbortOnConnectFail = false;
                return ConnectionMultiplexer.Connect(options);
            })
            .AddDbContext<PostgresDbContext>(options =>
                options.UseNpgsql(connectionDatabase))
            .AddScoped<ISessionStorage, RedisSessionStorage>()
            .AddScoped<IEventStorage, EventStorage>();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IWebBackendService, WebBackendService>();
    }

    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        return services
            .AddScoped<IEventManager, EventManager>();
    }

    private static IServiceCollection AddHttpClientFactory(this IServiceCollection services)
    {
        return services
            .AddSingleton<RequestFactory, RequestFactory>()
            .AddHttpClient();
    }
}