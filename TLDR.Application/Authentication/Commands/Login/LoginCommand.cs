using MediatR;
using TLDR.Application.Authentication.Common;
using TLDR.Application.Authentication.Dtos;

namespace TLDR.Application.Authentication.Commands.Login;

public record LoginCommand(UserDto UserDto) : IRequest<AuthenticationResponse>;