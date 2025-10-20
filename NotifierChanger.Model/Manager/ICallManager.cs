using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Manager;

public interface ICallManager
{
    Task<bool> TrySendCallEvent(CallEventDto dto);
}