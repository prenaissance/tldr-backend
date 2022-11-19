using AutoMapper;
using TLDR.Domain.Entities.Authentication;
using TLDR.Domain.Entities.Authentication.Enums;

namespace TLDR.Application.Authentication.Dtos;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<Roles>(src.Role.ToUpper())));

    }
}