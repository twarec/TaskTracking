using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Querys;

internal class GetTasksRangeQueryHandler(IRepository<TaskEntity> repository, IMapper mapper) : IRequestHandler<GetTasksRangeQuery, IEnumerable<TaskDto>>
{
    public async Task<IEnumerable<TaskDto>> Handle(GetTasksRangeQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAll()
            .OrderByDescending(_ => _.DateCreate)
            .Skip(request.Range.Offset)
            .Take(request.Range.Count)
            .Select(_ => mapper.Map<TaskDto>(_))
            .ToListAsync();
    }
}
