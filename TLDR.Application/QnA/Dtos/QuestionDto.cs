namespace TLDR.Application.QnA.Dtos;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Role = null!;
}