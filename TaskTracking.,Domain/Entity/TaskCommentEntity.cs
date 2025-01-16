namespace TaskTracking.Domain.Entity;

public class TaskCommentEntity
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }

    public string Comment { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public TaskEntity Task { get; set; } = default!;
    public UserEntity User { get; set; } = default!;
}
