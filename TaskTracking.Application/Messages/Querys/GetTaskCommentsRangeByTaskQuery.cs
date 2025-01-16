using MediatR;
using TaskTracking.Domain.Dtol;
using TaskTracking.Domain.Models;

namespace TaskTracking.Application.Messages.Querys;

public record GetTaskCommentsRangeByTaskQuery(Guid TaskId, RangePagination Range) : IRequest<IEnumerable<TaskCommentDto>>;
