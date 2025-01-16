using MediatR;
using TaskTracking.Domain.Dtol;

namespace TaskTracking.Application.Messages.Commands;

public record CreateTaskCommentsRangeCommand(Guid TaskId, Guid UserId, string Comment) : IRequest<TaskCommentDto>;
