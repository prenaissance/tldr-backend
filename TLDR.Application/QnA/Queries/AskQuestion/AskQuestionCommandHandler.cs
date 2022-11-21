using AutoMapper;
using MediatR;
using TLDR.Application.QnA.Dtos;
using TLDR.Domain.Entities.Authentication.Enums;
using TLDR.Domain.Entities.QnA;
using TLDR.Domain.Entities.QnA.Repositories;

namespace TLDR.Application.QnA.Queries.AskQuestion;

public class AskQuestionCommandHandler : IRequestHandler<AskQuestionCommand, QuestionDto?>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public AskQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuestionDto?> Handle(AskQuestionCommand request, CancellationToken cancellationToken)
    {
        var role = Enum.Parse<Roles>(request.Role.ToUpper());
        var questionIsUnique = _questionRepository.GetAll().All(q => q.Title != request.Title);
        if (!questionIsUnique)
        {
            return null;
        }
        var question = new Question
        {
            Title = request.Title,
            Role = role
        };
        var response = await _questionRepository.AddAsync(question);

        return _mapper.Map<QuestionDto>(response);
    }
}