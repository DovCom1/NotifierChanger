using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Manager;
using NotifierChanger.Model.Storage;

namespace NotifierChanger.Service.Manager;

public class StorageManager(IEventStorage storage) : IStorageManager
{
    public async Task TryWriteEvent(EventDto dto)
    {
        switch (dto.TypeDto)
        {
            case "SendMessage":
                await storage.AddMessageEvent(dto);
                break;
            case "Invite":
                await storage.AddInviteEvent(dto);
                break;
        }
    }
}