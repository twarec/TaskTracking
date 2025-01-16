using AutoMapper;
using MediatR;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Commands;

public class EditTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper) : IRequestHandler<EditTaskCommand, TaskDto>
{
    public async Task<TaskDto> Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.TaskId);

        entity.Name = request.Name ?? entity.Name;
        entity.Description = request.Description ?? entity.Description;
        entity.Weight = request.Weight ?? entity.Weight;
        entity.Status = request.Status ?? entity.Status;

        await repository.UpdateAsync(entity);

        return mapper.Map<TaskDto>(entity);
    }
}
