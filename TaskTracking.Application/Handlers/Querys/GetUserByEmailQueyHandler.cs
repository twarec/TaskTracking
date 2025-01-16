using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Exceptions;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Querys;

public class GetUserByEmailQueyHandler(IRepository<UserEntity> repository, IMapper mapper) : IRequestHandler<GetUserByEmailQuey, UserDto>
{
    public async Task<UserDto> Handle(GetUserByEmailQuey request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetAll()
            .SingleOrDefaultAsync(_ => _.Email == request.email)
            ?? throw new NotFoundException();

        return mapper.Map<UserDto>(entity);
    }
}
