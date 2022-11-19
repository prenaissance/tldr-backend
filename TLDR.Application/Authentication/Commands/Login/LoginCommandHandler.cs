using AutoMapper;
using MediatR;
using TLDR.Application.Authentication.Common;
using TLDR.Application.Authentication.Services;
using TLDR.Domain.Entities.Authentication;

namespace TLDR.Application.Authentication.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResponse>
{
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IJwtGenerator jwtGenerator, IMapper mapper)
    {
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.UserDto);
        return await Task.FromResult(new AuthenticationResponse
        {
            AccessToken = _jwtGenerator.CreateToken(user)
        });
    }
}