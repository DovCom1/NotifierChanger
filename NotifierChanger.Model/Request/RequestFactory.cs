using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Request;

public class RequestFactory(IOptions<RequestDomains> options)
{
    private RequestDomains _domains = options.Value;
    
    public HttpRequestMessage CreateIsOnlineUserRequest(int userId)
    {
        return new HttpRequestMessage(HttpMethod.Head, 
            _domains.WebBackend + RequestPath.IsOnline + $"/{userId}");
    }

    public HttpRequestMessage CreateSendMessageRequest(MessageEventDto dto)
    {
        var json = JsonSerializer.Serialize(dto);
        return new HttpRequestMessage(HttpMethod.Post,
            _domains.WebBackend + RequestPath.SendMessage)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
    }
}