using MediatR;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Enums;

namespace TaskTracking.Application.Messages.Commands;

public record CreateTaskUserCommand(Guid UserId, Guid TaskId, TaskUserRole Role) : IRequest<TaskUserDto>;
