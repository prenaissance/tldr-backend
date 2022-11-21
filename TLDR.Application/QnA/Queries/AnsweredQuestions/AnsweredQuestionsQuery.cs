using MediatR;
using TLDR.Application.QnA.Dtos;

namespace TLDR.Application.QnA.Queries.AnsweredQuestions;

public record AnsweredQuestionsQuery(string Search = "") : IRequest<AnsweredQuestionDto[]>;