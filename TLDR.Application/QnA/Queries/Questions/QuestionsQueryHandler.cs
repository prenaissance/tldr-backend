using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TLDR.Application.QnA.Dtos;
using TLDR.Domain.Entities.QnA;
using TLDR.Domain.Entities.QnA.Repositories;

namespace TLDR.Application.QnA.Queries.Questions;

public class QuestionsQueryHandler : IRequestHandler<QuestionsQuery, QuestionDto[]>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public QuestionsQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public Task<QuestionDto[]> Handle(QuestionsQuery request, CancellationToken cancellationToken)
    {
        // TODO: Add pagination
        var (search, onlyUnanswered) = request;

        var filtered = _questionRepository
            .GetAllAggregates()
            .Where(q => q.Answers.Count == 0 == !onlyUnanswered)
            .Where(q => q.Title.Contains(search))
            .ProjectTo<QuestionDto>(_mapper.ConfigurationProvider);

        return Task.FromResult(filtered.ToArray());
    }
}