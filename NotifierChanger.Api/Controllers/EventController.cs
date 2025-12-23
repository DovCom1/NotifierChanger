using Microsoft.AspNetCore.Mvc;
using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Manager;

namespace NotifierChanger.Api.Controllers;

[ApiController]
[Route("internal/[controller]")]
public class EventController(
    ILogger<EventController> logger, 
    IEventManager eventManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetMessageEvent([FromBody] EventDto dto)
    {
        var completedSuccessfully = await eventManager.TrySendEvent(dto);
        return completedSuccessfully ? Ok() : BadRequest("failed to record message");
    }
}