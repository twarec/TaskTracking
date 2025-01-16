using AutoMapper;
using TackTracking.Grpc.Comment;
using TackTracking.Grpc.Task;
using TackTracking.Grpc.User;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Dtol;

namespace TackTracking.Grpc.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, UserResponce>()
            .ForMember(_ => _.Id, _ => _.MapFrom(src => src.Id.ToString()))
            .ForMember(_ => _.Name, _ => _.MapFrom(src => src.Name))
            .ForMember(_ => _.Email, _ => _.MapFrom(src => src.Email))
            .ForMember(_ => _.DateCreate, _ => _.MapFrom(src => src.DateCreate.ToString()));

        CreateMap<UserResponce, UserDto>()
            .ForMember(_ => _.Id, _ => _.MapFrom(src => Guid.Parse(src.Id)))
            .ForMember(_ => _.Name, _ => _.MapFrom(src => src.Name))
            .ForMember(_ => _.Email, _ => _.MapFrom(src => src.Email))
            .ForMember(_ => _.DateCreate, _ => _.MapFrom(src => DateTime.Parse(src.DateCreate)));

        CreateMap<TaskDto, TaskResponce>()
            .ForMember(_ => _.Id, _ => _.MapFrom(src => src.Id.ToString()))
            .ForMember(_ => _.CreatorId, _ => _.MapFrom(src => src.CreatorId.ToString()))
            .ForMember(_ => _.Weight, _ => _.MapFrom(src => src.Weight))
            .ForMember(_ => _.Name, _ => _.MapFrom(src => src.Name))
            .ForMember(_ => _.Description, _ => _.MapFrom(src => src.Description))
            .ForMember(_ => _.Status, _ => _.MapFrom(src => Enum.Parse<Task.TaskStatus>(src.Status.ToString())))
            .ForMember(_ => _.DateCreate, _ => _.MapFrom(src => src.DateCreate.ToString()))
            .ForMember(_ => _.DateUpdate, _ => _.MapFrom(src => src.DateUpdate.ToString()));

        CreateMap<TaskCommentDto, TaskCommentResponce>()
            .ForMember(_ => _.Id, _ => _.MapFrom(src => src.Id.ToString()))
            .ForMember(_ => _.UserId, _ => _.MapFrom(src => src.UserId.ToString()))
            .ForMember(_ => _.TaskId, _ => _.MapFrom(src => src.TaskId.ToString()))
            .ForMember(_ => _.Comment, _ => _.MapFrom(src => src.Comment))
            .ForMember(_ => _.DateCreate, _ => _.MapFrom(src => src.DateCreated.ToString()))
            .ForMember(_ => _.DateUpdate, _ => _.MapFrom(src => src.DateUpdated.ToString()));

        CreateMap<TaskUserDto, TaskUserResponce>()
            .ForMember(_ => _.Id, _ => _.MapFrom(src => src.Id.ToString()))
            .ForMember(_ => _.TaskId, _ => _.MapFrom(src => src.TaskId.ToString()))
            .ForMember(_ => _.Role, _ => _.MapFrom(src => src.Role.ToString()));
    }
}
