using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Enums;
using TaskTracking.Domain.Models;

namespace TackTracking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(IMediator mediator) : Controller
{
    [HttpGet("range")]
    public async Task<IActionResult> GetRangeAsync([FromQuery] int offset, [FromQuery] int count)
    {
        return Ok(await mediator.Send(new GetTasksRangeQuery(new RangePagination(offset, count))));
    }

    [HttpGet("range/creator/{userId}")]
    public async Task<IActionResult> GetRangeByCreatorAsync([FromRoute] Guid userId, [FromQuery] int offset, [FromQuery] int count)
    {
        return Ok(await mediator.Send(new GetTasksRangeByCreatorQuery(userId, new RangePagination(offset, count))));
    }

    [HttpGet("range/mamber/{userId}")]
    public async Task<IActionResult> GetRangeByMamberAsync([FromRoute] Guid userId, [FromQuery] int offset, [FromQuery] int count)
    {
        return Ok(await mediator.Send(new GetTasksRangeByMemberQuery(userId, new RangePagination(offset, count))));
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> CreateAsync([FromRoute] Guid userId, [FromQuery] string name, [FromQuery] string description, [FromQuery] int weight)
    {
        return Ok(await mediator.Send(new CreateTaskCommand(userId, name, description, weight)));
    }

    [HttpPost("{taskId}/join/user/{userId}")]
    public async Task<IActionResult> JoinUserAsync([FromRoute] Guid taskId, [FromRoute] Guid userId, [FromQuery] TaskUserRole role)
    {
        return Ok(await mediator.Send(new CreateTaskUserCommand(userId, taskId, role)));
    }

    [HttpPatch("{taskId}")]
    public async Task<IActionResult> EditTaskAsync([FromRoute] Guid taskId, [FromRoute] string? name, [FromRoute] string? description, [FromRoute] int? weight, [FromRoute] TaskTracking.Domain.Enums.TaskStatus? status)
    {
        return Ok(await mediator.Send(new EditTaskCommand(taskId, status, weight, name, description)));
    }
}
