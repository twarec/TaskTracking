using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Models;

namespace TackTracking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : Controller
{
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail([FromRoute] string email)
    {
        return Ok(await mediator.Send(new GetUserByEmailQuey(email)));
    }

    [HttpGet("range")]
    public async Task<IActionResult> GetRangeAsync([FromQuery] int offset, [FromQuery] int count)
    {
        return Ok(await mediator.Send(new GetUsersRangeQuery(new RangePagination(offset, count))));
    }

    [HttpPut]
    public async Task<IActionResult> CreateAsunc([FromQuery] string name, [FromQuery] string email)
    {
        return Ok(await mediator.Send(new CreateUserCommand(name, email)));
    }
}
