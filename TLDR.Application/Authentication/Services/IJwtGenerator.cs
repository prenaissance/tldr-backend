using TLDR.Domain.Entities.Authentication;

namespace TLDR.Application.Authentication.Services;

public interface IJwtGenerator
{
    string CreateToken(User user);
}