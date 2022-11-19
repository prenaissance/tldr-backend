using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.QnA;

public class Answer : BaseEntity<Guid>
{
    public string Description { get; set; } = default!;
    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = default!;
    public IList<Question> FollowingQuestions { get; set; } = default!;
}
