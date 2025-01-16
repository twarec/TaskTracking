using AutoMapper;
using Grpc.Core;
using MediatR;
using TackTracking.Grpc.Comment;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Models;

namespace TackTracking.Grpc.Services.Grpc;

public class TaskCommentService(IMediator mediator, IMapper mapper) : Comment.TaskComment.TaskCommentBase
{
    public override async Task<TaskCommentArrayResponce> GetRangeByTask(GetTaskCommentRangeByTaskRequest request, ServerCallContext context)
    {
        var result = new TaskCommentArrayResponce();
        var comments = await mediator.Send(new GetTaskCommentsRangeByTaskQuery(Guid.Parse(request.TaskId), new RangePagination(request.Range.Offset, request.Range.Count)));
        result.Comments.AddRange(comments.Select(mapper.Map<TaskCommentResponce>));

        return result;
    }

    public override async Task<TaskCommentResponce> Create(CreateTaskCommentRequest request, ServerCallContext context)
    {
        return mapper.Map<TaskCommentResponce>(await mediator.Send(new CreateTaskCommentsRangeCommand(Guid.Parse(request.TaskId), Guid.Parse(request.UserId), request.Comment)));
    }
}
