using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Manager;

public interface IStorageManager
{
    Task TryWriteEvent(EventDto dto);
}