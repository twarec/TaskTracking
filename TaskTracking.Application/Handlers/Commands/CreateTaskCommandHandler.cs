using AutoMapper;
using MediatR;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Commands;

public class CreateTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper) : IRequestHandler<CreateTaskCommand, TaskDto>
{
    public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.CreateAsync(new TaskEntity
        {
            Id = Guid.NewGuid(),
            CreatorId = request.userId,
            Name = request.Name,
            Description = request.Description,
            DateCreate = DateTime.UtcNow,
            DateUpdate = DateTime.UtcNow,
        });
        return mapper.Map<TaskDto>(entity);
    }
}
