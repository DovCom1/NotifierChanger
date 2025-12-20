using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Service;

public interface IWebBackendService
{
    Task<bool> SendEvent(MessageEventDto dto);
    
}