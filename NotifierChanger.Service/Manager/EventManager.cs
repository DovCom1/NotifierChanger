using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Manager;
using NotifierChanger.Model.Service;
using NotifierChanger.Model.Storage;

namespace NotifierChanger.Service.Manager;

public class EventManager(
    IWebBackendService webBackendService,
    ISessionStorage sessionStorage,
    IEventStorage eventStorage) : IEventManager
{
    public async Task<bool> TrySendMessage(MessageEventDto dto)
    {
        var isOnline = await sessionStorage.isUserOnline(dto.ReceiverId);
        if (isOnline)
        {
            var requestStatus = await webBackendService.SendEvent(dto);
            if (!requestStatus) return false;
        }
        await eventStorage.AddMessageEvent(dto);

        return true;
    }
    
    public async Task<bool> TrySendCall(CallEventDto dto)
    {
        var isOnline = await sessionStorage.isUserOnline(dto.ReceiverId);
        if (isOnline)
        {
            var requestStatus = await webBackendService.SendEvent(dto);
            if (!requestStatus) return false;
        }
        await eventStorage.AddCallEvent(dto);

        return true;
    }

    public async Task<bool> TrySendInvite(InviteEventDto dto)
    {
        var isOnline = await sessionStorage.isUserOnline(dto.ReceiverId);
        if (isOnline)
        {
            var requestStatus = await webBackendService.SendEvent(dto);
            if (!requestStatus) return false;
        }
        await eventStorage.AddInviteEvent(dto);

        return true;
    }
}