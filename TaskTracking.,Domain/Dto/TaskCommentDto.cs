namespace TaskTracking.Domain.Dtol;

public class TaskCommentDto
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public string Comment { get; set; } = string.Empty;
}
