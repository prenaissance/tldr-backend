using TLDR.Domain.Entities.Authentication.Enums;
using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.QnA;

public class Question : BaseEntity<Guid>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Roles Role { get; set; }
    public IList<Answer> Answers { get; set; } = null!;
}