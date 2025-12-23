using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotifierChanger.Model.Dto;

namespace NotifierChanger.Model.Request;

public class RequestFactory(IOptions<RequestDomains> options)
{
    private RequestDomains _domains = options.Value;

    public HttpRequestMessage CreateSendMessageRequest(string jsonDto)
    {
        Console.WriteLine($"IEvent DTO: {jsonDto}");
        var path = RequestPath.Base;
        
        return new HttpRequestMessage(HttpMethod.Post,
            _domains.WebBackend + path)
        {
            Content = new StringContent(jsonDto, Encoding.UTF8, "application/json")
        };
    }
    
    
}