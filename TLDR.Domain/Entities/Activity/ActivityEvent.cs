using TLDR.Domain.Entities.Activity.Enums;
using TLDR.Domain.Entities.Authentication;
using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.Activity;

public class ActivityEvent : BaseEntity<Guid>
{
    public Guid ActorId { get; set; }
    public User Actor { get; set; } = null!;
    public ActivityTypes ActivityType { get; set; } = default;
    public DateTime CreatedAt { get; set; }
    public string? Data { get; set; }
}