using AutoMapper;
using MediatR;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Domain.Dtol;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Commands;

public class CreateTaskCommentCommandHandler(IRepository<TaskCommentEntity> repository, IMapper mapper) : IRequestHandler<CreateTaskCommentsRangeCommand, TaskCommentDto>
{
    public async Task<TaskCommentDto> Handle(CreateTaskCommentsRangeCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.CreateAsync(new TaskCommentEntity
        {
            Id = Guid.NewGuid(),
            Comment = request.Comment,
            TaskId = request.TaskId,
            UserId = request.UserId,
            DateCreated = DateTime.UtcNow,
            DateUpdated = DateTime.UtcNow,
        });

        return mapper.Map<TaskCommentDto>(entity);
    }
}
