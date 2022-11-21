namespace TLDR.Application.QnA.Dtos;

public record CreateAnswerDto(Guid QuestionId, string Description);