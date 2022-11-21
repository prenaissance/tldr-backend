using AutoMapper;
using TLDR.Domain.Entities.QnA;

namespace TLDR.Application.QnA.Dtos;

public class QnAMappingProfile : Profile
{
    public QnAMappingProfile()
    {
        CreateMap<Question, QuestionDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString().ToLower()));

        CreateMap<Answer, AnswerDto>();

        CreateMap<Question, AnsweredQuestionDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString().ToLower()));
    }
}