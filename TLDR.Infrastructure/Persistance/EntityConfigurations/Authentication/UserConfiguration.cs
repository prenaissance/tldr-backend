namespace TLDR.Infrastructure.Persistance.EntityConfigurations.Authentication;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLDR.Domain.Entities.Authentication;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Activities)
            .WithOne(a => a.Actor)
            .HasForeignKey(a => a.ActorId);
    }
}