using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Querys;

public class GetUsersRangeQueryHandler(IRepository<UserEntity> repository, IMapper mapper) : IRequestHandler<GetUsersRangeQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetUsersRangeQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAll()
            .OrderBy(_ => _.DateCreate)
            .Skip(request.Range.Offset)
            .Take(request.Range.Count)
            .Select(_ => mapper.Map<UserDto>(_))
            .ToListAsync();
    }
}
