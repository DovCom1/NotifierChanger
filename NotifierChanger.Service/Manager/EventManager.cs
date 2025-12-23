using System.Text.Json;
using Microsoft.Extensions.Logging;
using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Manager;
using NotifierChanger.Model.Service;
using NotifierChanger.Model.Storage;

namespace NotifierChanger.Service.Manager;

public class EventManager(
    IWebBackendService webBackendService,
    ISessionStorage sessionStorage,
    IEventStorage eventStorage,
    IStorageManager storageManager,
    ILogger<EventManager> logger) : IEventManager
{
    public async Task<bool> TrySendEvent(EventDto dto)
    {
        var isOnline = await sessionStorage.isUserOnline(dto.ReceiverId);
        if (isOnline)
        {
            logger.LogInformation($"user {dto.ReceiverId} is online");
            logger.LogInformation($"Notification: {dto}");
            var json = JsonSerializer.Serialize(dto);
            var requestStatus = await webBackendService.SendEvent(json);
            if (!requestStatus) return false;
        }
        await storageManager.TryWriteEvent(dto);

        return true;
    }
}