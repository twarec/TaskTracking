using MediatR;
using TaskTracking.Domain.Dto;

namespace TaskTracking.Application.Messages.Commands;

public record CreateUserCommand(string Name, string Email) : IRequest<UserDto>;