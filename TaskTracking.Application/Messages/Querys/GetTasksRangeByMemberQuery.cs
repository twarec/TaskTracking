using MediatR;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Models;

namespace TaskTracking.Application.Messages.Querys;

public record GetTasksRangeByMemberQuery(Guid UserId, RangePagination Range) : IRequest<IEnumerable<TaskUserDto>>;
