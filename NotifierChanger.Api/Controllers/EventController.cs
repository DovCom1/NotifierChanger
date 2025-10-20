using Microsoft.AspNetCore.Mvc;
using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Manager;

namespace NotifierChanger.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(
    ILogger<EventController> logger, 
    IMessageManager messageManager,
    ICallManager callManager,
    IInviteManager inviteManager) : ControllerBase
{
    private readonly ILogger<EventController> _logger = logger;
    private readonly IMessageManager _messageManager = messageManager;
    private readonly ICallManager _callManager = callManager;
    private readonly IInviteManager _inviteManager = inviteManager;

    [HttpPost("take-event/message")]
    public async Task<IActionResult> GetMessageEvent([FromBody] MessageEventDto dto)
    {
        var completedSuccessfully = await _messageManager.TrySendMessage(dto);
        return completedSuccessfully ? Ok() : BadRequest("failed to record message");
    }

    [HttpPost("take-event/call")]
    public async Task<IActionResult> GetCallEvent([FromBody] CallEventDto dto)
    {
        var completedSuccessfully = await _callManager.TrySendCallEvent(dto);
        return completedSuccessfully ? Ok() : BadRequest("failed to record call");
    }
    
    [HttpPost("take-event/invite")]
    public async Task<IActionResult> GetInviteEvent([FromBody] InviteEventDto dto)
    {
        var completedSuccessfully = await _inviteManager.TrySendInvite(dto);
        return completedSuccessfully ? Ok() : BadRequest("failed to record invite");
    }
}