using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TLDR.Application.QnA.Dtos;
using TLDR.Domain.Entities.QnA.Repositories;

namespace TLDR.Application.QnA.Queries.AnsweredQuestions;

public class AnsweredQuestionsQueryHandler : IRequestHandler<AnsweredQuestionsQuery, AnsweredQuestionDto[]>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public AnsweredQuestionsQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public Task<AnsweredQuestionDto[]> Handle(AnsweredQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = _questionRepository
            .GetAllAggregates()
            .Where(q => q.Answers.Count > 0)
            .Where(q => q.Title.Contains(request.Search))
            .ProjectTo<AnsweredQuestionDto>(_mapper.ConfigurationProvider)
            .ToArray();

        return Task.FromResult(questions);
    }
}