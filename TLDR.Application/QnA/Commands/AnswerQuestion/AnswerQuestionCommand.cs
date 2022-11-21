using MediatR;
using TLDR.Application.QnA.Dtos;

namespace TLDR.Application.QnA.Commands.AnswerQuestion;

public record AnswerQuestionCommand(Guid QuestionId, string Answer) : IRequest<AnsweredQuestionDto?>;