using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Storage;

public interface IEventStorage
{
    Task AddMessageEvent(EventDto dto);
    Task AddInviteEvent(EventDto dto);
}