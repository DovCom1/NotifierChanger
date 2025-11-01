using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Request;
using NotifierChanger.Model.Service;

namespace NotifierChanger.Service.Service;

public class WebBackendService(
    IHttpClientFactory clientFactory,
    RequestFactory requestFactory) : IWebBackendService
{
    private readonly IHttpClientFactory _clientFactory = clientFactory;
    private readonly RequestFactory _requestFactory =  requestFactory;
    
    public async Task<bool> isUserOnline(int userId)
    {
        var client = _clientFactory.CreateClient("WebBackend");
        var response = await client.SendAsync(_requestFactory.CreateIsOnlineUserRequest(userId));
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> SendEvent(IEventDto dto)
    {
        var client = _clientFactory.CreateClient("WebBackend");
        var response = await client.SendAsync(_requestFactory.CreateSendMessageRequest(dto));
        return response.IsSuccessStatusCode;
    }
}