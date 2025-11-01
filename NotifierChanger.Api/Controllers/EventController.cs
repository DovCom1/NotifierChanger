using Microsoft.AspNetCore.Mvc;
using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Manager;

namespace NotifierChanger.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(
    ILogger<EventController> logger, 
    IEventManager eventManager) : ControllerBase
{

    [HttpPost("take-event/message")]
    public async Task<IActionResult> GetMessageEvent([FromBody] MessageEventDto dto)
    {
        var completedSuccessfully = await eventManager.TrySendMessage(dto);
        return completedSuccessfully ? Ok() : BadRequest("failed to record message");
    }

    [HttpPost("take-event/call")]
    public async Task<IActionResult> GetCallEvent([FromBody] CallEventDto dto)
    {
        var completedSuccessfully = await eventManager.TrySendCall(dto);
        return completedSuccessfully ? Ok() : BadRequest("failed to record call");
    }
    
    [HttpPost("take-event/invite")]
    public async Task<IActionResult> GetInviteEvent([FromBody] InviteEventDto dto)
    {
        var completedSuccessfully = await eventManager.TrySendInvite(dto);
        return completedSuccessfully ? Ok() : BadRequest("failed to record invite");
    }
}