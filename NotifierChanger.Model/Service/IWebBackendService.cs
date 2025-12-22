using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Service;

public interface IWebBackendService
{
    Task<bool> SendEvent(string jsonDto);
    
}