using MediatR;
using TaskTracking.Domain.Dto;

namespace TaskTracking.Application.Messages.Querys;

public record GetUserByEmailQuey(string email) : IRequest<UserDto>;

