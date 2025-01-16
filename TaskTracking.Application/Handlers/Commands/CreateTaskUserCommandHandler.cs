using AutoMapper;
using MediatR;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Commands;

public class CreateTaskUserCommandHandler(IRepository<TaskUserEntity> repository, IMapper mapper) : IRequestHandler<CreateTaskUserCommand, TaskUserDto>
{
    public async Task<TaskUserDto> Handle(CreateTaskUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.CreateAsync(new TaskUserEntity
        {
            Id = Guid.NewGuid(),
            Role = request.Role,
            TaskId = request.TaskId,
            UserId = request.UserId,
        });

        return mapper.Map<TaskUserDto>(entity);
    }
}
