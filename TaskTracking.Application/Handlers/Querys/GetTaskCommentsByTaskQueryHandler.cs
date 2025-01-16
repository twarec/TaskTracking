using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Dtol;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Querys;

public class GetTaskCommentsByTaskQueryHandler(IRepository<TaskCommentEntity> repository, IMapper mapper) : IRequestHandler<GetTaskCommentsRangeByTaskQuery, IEnumerable<TaskCommentDto>>
{
    public async Task<IEnumerable<TaskCommentDto>> Handle(GetTaskCommentsRangeByTaskQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAll()
            .OrderByDescending(_ => _.DateCreated)
            .Where(_ => _.TaskId == request.TaskId)
            .Skip(request.Range.Offset)
            .Take(request.Range.Count)
            .Select(_ => mapper.Map<TaskCommentDto>(_))
            .ToListAsync();
    }
}
