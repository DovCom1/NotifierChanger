using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Manager;

public interface IEventManager
{
    Task<bool> TrySendEvent(EventDto dto);
}