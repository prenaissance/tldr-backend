namespace TLDR.Application.QnA.Dtos;

public class AnswerDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public QuestionDto Question { get; set; } = null!;
    public IList<QuestionDto> FollowingQuestions { get; set; } = null!;
}