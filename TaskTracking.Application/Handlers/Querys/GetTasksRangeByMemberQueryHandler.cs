using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Querys;

public class GetTasksRangeByMemberQueryHandler(IRepository<TaskUserEntity> repository, IMapper mapper) : IRequestHandler<GetTasksRangeByMemberQuery, IEnumerable<TaskUserDto>>
{
    public async Task<IEnumerable<TaskUserDto>> Handle(GetTasksRangeByMemberQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAll()
            .Include(_ => _.Task)
            .OrderBy(_ => _.Task.Weight)
            .Where(_ => _.UserId == request.UserId && _.Task.Status != Domain.Enums.TaskStatus.Closed)
            .Skip(request.Range.Offset)
            .Take(request.Range.Count)
            .Select(_ => mapper.Map<TaskUserDto>(_))
            .ToListAsync();
    }
}
