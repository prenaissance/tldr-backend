using TLDR.Domain.Entities.Authentication.Enums;
using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.Authentication;
public class User : BaseEntity<Guid>
{
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = default!;
    public Roles Role { get; set; }
}
