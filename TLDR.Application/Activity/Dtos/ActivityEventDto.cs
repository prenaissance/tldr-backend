namespace TLDR.Application.Activity.Dtos;

public class ActivityEventDto
{
    public string ActivityType { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string? Data { get; set; }
}