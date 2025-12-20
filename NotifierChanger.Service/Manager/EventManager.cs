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
    ILogger<EventManager> logger) : IEventManager
{
    public async Task<bool> TrySendMessage(MessageEventDto dto)
    {
        var isOnline = await sessionStorage.isUserOnline(dto.ReceiverId);
        if (isOnline)
        {
            logger.LogInformation($"user {dto.ReceiverId} is online");
            logger.LogInformation($"Notification: {dto}");
            var requestStatus = await webBackendService.SendEvent(dto);
            if (!requestStatus) return false;
        }
        await eventStorage.AddMessageEvent(dto);

        return true;
    }
    
    // public async Task<bool> TrySendCall(CallEventDto dto)
    // {
    //     var isOnline = await sessionStorage.isUserOnline(dto.ReceiverId);
    //     if (isOnline)
    //     {
    //         var requestStatus = await webBackendService.SendEvent(dto);
    //         if (!requestStatus) return false;
    //     }
    //     await eventStorage.AddCallEvent(dto);
    //
    //     return true;
    // }
    //
    // public async Task<bool> TrySendInvite(InviteEventDto dto)
    // {
    //     var isOnline = await sessionStorage.isUserOnline(dto.ReceiverId);
    //     if (isOnline)
    //     {
    //         var requestStatus = await webBackendService.SendEvent(dto);
    //         if (!requestStatus) return false;
    //     }
    //     await eventStorage.AddInviteEvent(dto);
    //
    //     return true;
    // }
}