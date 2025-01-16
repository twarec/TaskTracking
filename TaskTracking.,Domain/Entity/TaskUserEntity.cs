using TaskTracking.Domain.Enums;

namespace TaskTracking.Domain.Entity;

public class TaskUserEntity
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }

    public TaskUserRole Role { get; set; } = TaskUserRole.Executer;

    public UserEntity User { get; set; } = default!;
    public TaskEntity Task { get; set; } = default!;
}
