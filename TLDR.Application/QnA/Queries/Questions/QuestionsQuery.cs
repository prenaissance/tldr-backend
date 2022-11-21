using MediatR;
using TLDR.Application.QnA.Dtos;

namespace TLDR.Application.QnA.Queries.Questions;

public record QuestionsQuery(string Search = "", bool OnlyUnanswered = false) : IRequest<QuestionDto[]>;