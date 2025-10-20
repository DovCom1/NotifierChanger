using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Manager;

public interface IInviteManager
{
    Task<bool> TrySendInvite(InviteEventDto dto);
}