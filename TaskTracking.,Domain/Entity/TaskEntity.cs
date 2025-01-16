namespace TaskTracking.Domain.Entity;

public class TaskEntity
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public int Weight { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.Wait;

    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }

    public UserEntity Creator { get; set; } = default!;

    public List<TaskCommentEntity> Comments { get; set; } = [];
    public List<TaskUserEntity> TaskUsers { get; set; } = [];
}
