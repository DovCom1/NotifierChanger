using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Manager;
using NotifierChanger.Model.Service;
using NotifierChanger.Model.Storage;

namespace NotifierChanger.Service.Manager;

public class MessageManager(
    IWebBackendService webBackendService,
    IEventStorage eventStorage) : IMessageManager
{
    private readonly IWebBackendService _webBackendService = webBackendService;
    private readonly IEventStorage _eventStorage = eventStorage;
    public async Task<bool> TrySendMessage(MessageEventDto dto)
    {
        var isOnline = await _webBackendService.isUserOnline(dto.ReceiverId);
        if (isOnline)
        {
            var requestStatus = await _webBackendService.SendMessage(dto);
            if (!requestStatus) return false;
        }
        await _eventStorage.AddMessageEvent(dto);

        return true;
    }
}