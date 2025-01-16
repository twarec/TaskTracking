using AutoMapper;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Dtol;
using TaskTracking.Domain.Entity;

namespace TaskTracking.Application.Services;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<UserEntity, UserDto>().ReverseMap();
        CreateMap<TaskEntity, TaskDto>().ReverseMap();
        CreateMap<TaskCommentEntity, TaskCommentDto>().ReverseMap();
        CreateMap<TaskUserEntity, TaskUserDto>().ReverseMap();
    }
}
