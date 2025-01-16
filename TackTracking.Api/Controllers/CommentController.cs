using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Models;

namespace TackTracking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController(IMediator mediator) : Controller
{
    [HttpGet("range/task/{taskId}")]
    public async Task<IActionResult> GetRangeByTaskAsync([FromRoute] Guid taskId, [FromQuery] int offset, [FromQuery] int count)
    {
        return Ok(await mediator.Send(new GetTaskCommentsRangeByTaskQuery(taskId, new RangePagination(offset, count))));
    }

    [HttpPut("{userId}/{taskId}")]
    public async Task<IActionResult> CreateAsync([FromRoute] Guid userId, [FromRoute] Guid taskId, [FromQuery] string comment)
    {
        return Ok(await mediator.Send(new CreateTaskCommentsRangeCommand(taskId, userId, comment)));
    }
}
