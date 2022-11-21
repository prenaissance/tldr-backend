namespace TLDR.Application.QnA.Dtos;

public class AnsweredQuestionDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Role { get; set; } = null!;
    public AnswerDto[] Answers { get; set; } = null!;
}