using System.Net;
using AutoMapper;
using MediatR;
using TLDR.Application.QnA.Dtos;
using TLDR.Domain.Entities.QnA;
using TLDR.Domain.Entities.QnA.Repositories;

namespace TLDR.Application.QnA.Commands.AnswerQuestion;

public class AnswerQuestionCommandHandler : IRequestHandler<AnswerQuestionCommand, AnsweredQuestionDto?>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public AnswerQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<AnsweredQuestionDto?> Handle(AnswerQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = _questionRepository.GetAggregateById(request.QuestionId);
        if (question is null)
        {
            return null;
        }

        var answer = new Answer()
        {
            Description = request.Answer,
            QuestionId = request.QuestionId
        };
        question.Answers.Add(answer);
        await _questionRepository.UpdateAsync(question);
        return _mapper.Map<AnsweredQuestionDto>(question);
    }
}