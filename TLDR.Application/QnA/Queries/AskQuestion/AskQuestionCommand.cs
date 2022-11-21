using MediatR;
using TLDR.Application.QnA.Dtos;

namespace TLDR.Application.QnA.Queries.AskQuestion;

public record AskQuestionCommand(string Title, string Role) : IRequest<QuestionDto?>;