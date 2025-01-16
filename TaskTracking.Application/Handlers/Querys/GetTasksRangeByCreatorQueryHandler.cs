using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Querys;

public class GetTasksRangeByCreatorQueryHandler(IRepository<TaskEntity> repository, IMapper mapper) : IRequestHandler<GetTasksRangeByCreatorQuery, IEnumerable<TaskDto>>
{
    public async Task<IEnumerable<TaskDto>> Handle(GetTasksRangeByCreatorQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAll()
            .Where(_ => _.CreatorId == request.userId && _.Status != Domain.Enums.TaskStatus.Closed)
            .OrderBy(_ => _.Weight)
            .Skip(request.Range.Offset)
            .Take(request.Range.Count)
            .Select(_ => mapper.Map<TaskDto>(_))
            .ToListAsync();
    }
}
