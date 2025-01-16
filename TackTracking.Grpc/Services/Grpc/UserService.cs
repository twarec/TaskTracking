using AutoMapper;
using Grpc.Core;
using MediatR;
using TackTracking.Grpc.User;
using TaskTracking.Application.Messages.Commands;
using TaskTracking.Application.Messages.Querys;
using TaskTracking.Domain.Models;

namespace TackTracking.Grpc.Services.Grpc;

public class UserService(IMediator mediator, IMapper mapper) : User.User.UserBase
{
    public override async Task<UserResponce> Create(CreateUserRequest request, ServerCallContext context)
    {
        return mapper.Map<UserResponce>(await mediator.Send(new CreateUserCommand(request.Name, request.Email)));
    }

    public override async Task<UserResponce> GetByEmail(GetUserByEmailRequest request, ServerCallContext context)
    {
        return mapper.Map<UserResponce>(await mediator.Send(new GetUserByEmailQuey(request.Email)));
    }

    public override async Task<UserArrayResponce> GetRange(User.Range request, ServerCallContext context)
    {
        var responce = new UserArrayResponce();
        var users = await mediator.Send(new GetUsersRangeQuery(new RangePagination(request.Offset, request.Count)));
        responce.Users.AddRange(users.Select(mapper.Map<UserResponce>));

        return responce;
    }
}
