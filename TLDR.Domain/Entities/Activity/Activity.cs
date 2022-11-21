using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.Activity;

public class Activity : BaseEntity<Guid>
{
    public string ActorId { get; set; } = null!;
    public string ActivityType { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string? Data { get; set; }
}