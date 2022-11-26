using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLDR.Application.Activity.Queries.Activities;

namespace TLDR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{actorId}")]
    public async Task<IActionResult> GetActivities(
        Guid actorId,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 0)
    {
        var activities = await _mediator.Send(new ActivitiesQuery(actorId, page, pageSize));
        return Ok(activities);
    }
}