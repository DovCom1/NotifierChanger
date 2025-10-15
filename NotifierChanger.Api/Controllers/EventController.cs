using Microsoft.AspNetCore.Mvc;
using NotifierChanger.Model.Dto;

namespace NotifierChanger.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(ILogger<EventController> logger) : ControllerBase
{
    private readonly ILogger<EventController> _logger = logger;

    [HttpPost("message")]
    public async Task<IActionResult> GetEvent([FromBody] MessageEventDto dto)
    {
        
    }
}