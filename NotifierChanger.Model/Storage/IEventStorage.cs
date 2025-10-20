using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Storage;

public interface IEventStorage
{
    Task AddMessageEvent(MessageEventDto dto);
}