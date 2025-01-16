using TaskTracking.Domain.Enums;

namespace TaskTracking.Domain.Dto;

public class TaskUserDto
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }

    public TaskDto? Task { get; set; } = null;

    public TaskUserRole Role { get; set; } = TaskUserRole.Executer;
}
