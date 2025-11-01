using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Service;

public interface IWebBackendService
{
    Task<bool> isUserOnline(int userId);
    Task<bool> SendEvent(IEventDto dto);
    
}