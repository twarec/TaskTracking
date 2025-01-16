using TaskTracking.Domain.Enums;

namespace TaskTracking.Domain.Entity;

public class UserEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public DateTime DateCreate { get; set; }

    public List<TaskUserEntity> TaskUsers { get; set; } = [];
    public List<TaskEntity> Tasks { get; set; } = [];
}
