using AutoMapper;
using MediatR;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Application.Handlers.Commands;

public class CreateUserCommandHandler(IRepository<UserEntity> repository, IMapper mapper) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.CreateAsync(new UserEntity
        {
            Name = request.Name,
            Email = request.Email,
            DateCreate = DateTime.UtcNow,
        });

        return mapper.Map<UserDto>(entity);
    }
}
