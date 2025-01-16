using MediatR;
using TaskTracking.Domain.Dto;

namespace TaskTracking.Application.Messages.Commands;

public record EditTaskCommand(Guid TaskId, Domain.Enums.TaskStatus? Status, int? Weight, string? Name, string? Description) : IRequest<TaskDto>;
