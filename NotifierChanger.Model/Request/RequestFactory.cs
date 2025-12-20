using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Request;

public class RequestFactory(IOptions<RequestDomains> options)
{
    private RequestDomains _domains = options.Value;

    public HttpRequestMessage CreateSendMessageRequest(MessageEventDto dto)
    {
        Console.WriteLine($"IEvent DTO: {dto.ToString()}");
        var json = JsonSerializer.Serialize(dto);
        
        // var path = RequestPath.SendMessage;
        // if (dto is CallEventDto callEventDto)
        // {
        //     path = RequestPath.CallEvent;
        // }
        // else if (dto is InviteEventDto inviteEventDto)
        // {
        //     path = RequestPath.InviteEvent;
        // }
        var path = RequestPath.Base;
        Console.WriteLine($"Sending message with {json}");
        
        return new HttpRequestMessage(HttpMethod.Post,
            _domains.WebBackend + path)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
    }
    
    
}