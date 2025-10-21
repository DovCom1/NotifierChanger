using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;

namespace NotifierChanger.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(ILogger<EventController> logger) : ControllerBase
{
    private readonly ILogger<EventController> _logger = logger;
}