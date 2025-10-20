using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Manager;

public interface IMessageManager
{
    Task<bool> TrySendMessage(MessageEventDto dto);
}