using AutoMapper;
using Grpc.Core;
using MediatR;
using TackTracking.Grpc.Extensions;
using TackTracking.Grpc.Task;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Models;

namespace TackTracking.Grpc.Services.Grpc;

public class TaskService(IMediator mediator, IMapper mapper) : Task.Task.TaskBase
{
    public override async Task<TaskResponce> Create(CreateTaskRequest request, ServerCallContext context)
    {
        return mapper.Map<TaskResponce>(await mediator.Send(new CreateTaskCommand(Guid.Parse(request.UserId), request.Name, request.Description, request.Weight)));
    }

    public override async Task<TaskArrayResponce> GetRange(Task.Range request, ServerCallContext context)
    {
        var result = new TaskArrayResponce();
        var tasks = await mediator.Send(new GetTasksRangeQuery(new RangePagination(request.Offset, request.Count)));
        result.Tasks.AddRange(tasks.Select(mapper.Map<TaskResponce>));

        return result;
    }

    public override async Task<TaskArrayResponce> GetByCreator(GetByCreatorRequest request, ServerCallContext context)
    {
        var result = new TaskArrayResponce();
        var tasks = await mediator.Send(new GetTasksRangeByCreatorQuery(Guid.Parse(request.UserId), new RangePagination(request.Range.Offset, request.Range.Count)));
        result.Tasks.AddRange(tasks.Select(mapper.Map<TaskResponce>));

        return result;
    }

    public override async Task<TaskUserArrayResponce> GetByMamber(GetByMamberRequest request, ServerCallContext context)
    {
        var result = new TaskUserArrayResponce();
        var tasks = await mediator.Send(new GetTasksRangeByMemberQuery(Guid.Parse(request.UserId), new RangePagination(request.Range.Offset, request.Range.Count)));
        result.Tasks.AddRange(tasks.Select(mapper.Map<TaskUserResponce>));

        return result;
    }

    public override async Task<TaskUserResponce> JoinUserToTask(JoinUserToTaskRequest request, ServerCallContext context)
    {
        return mapper.Map<TaskUserResponce>(await mediator.Send(new CreateTaskUserCommand(Guid.Parse(request.UserId), Guid.Parse(request.TaskId), Enum.Parse<TaskTracking.Domain.Enums.TaskUserRole>(request.Role.ToString()))));
    }

    public override async Task<TaskResponce> Edit(EditTaskRequest request, ServerCallContext context)
    {
        return mapper.Map<TaskResponce>(await mediator.Send(new EditTaskCommand(Guid.Parse(request.TaskId), Enum.Parse<TaskTracking.Domain.Enums.TaskStatus>(request.Status.ToString()), request.Weight, request.Name, request.Description))); 
    }
}
