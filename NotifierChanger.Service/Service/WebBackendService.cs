using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Request;
using NotifierChanger.Model.Service;

namespace NotifierChanger.Service.Service;

public class WebBackendService(
    IHttpClientFactory clientFactory,
    RequestFactory requestFactory) : IWebBackendService
{
    public async Task<bool> SendEvent(string jsonDto)
    {
        var client = clientFactory.CreateClient("WebBackend");
        var response = await client.SendAsync(requestFactory.CreateSendMessageRequest(jsonDto));
        return response.IsSuccessStatusCode;
    }
}