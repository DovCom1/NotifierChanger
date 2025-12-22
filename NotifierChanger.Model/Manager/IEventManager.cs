using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Manager;

public interface IEventManager
{
    Task<bool> TrySendMessage(MessageEventDto dto);
    // Task<bool> TrySendCall(CallEventDto dto);
    Task<bool> TrySendInvite(InviteEventDto dto);
}