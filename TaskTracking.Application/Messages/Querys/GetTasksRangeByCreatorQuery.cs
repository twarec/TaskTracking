using MediatR;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Models;

namespace TaskTracking.Application.Messages.Querys;

public record GetTasksRangeByCreatorQuery(Guid userId, RangePagination Range) : IRequest<IEnumerable<TaskDto>>;

