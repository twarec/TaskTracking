using MediatR;
using TaskTracking.Domain.Dto;

namespace TaskTracking.Application.Messages.Commands;

public record CreateTaskCommand(Guid userId, string Name, string Description, int Weight) : IRequest<TaskDto>;
