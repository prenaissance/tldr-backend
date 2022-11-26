namespace TLDR.Infrastructure.Persistance.EntityConfigurations.Activity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLDR.Domain.Entities.Activity;

public class ActivityConfiguration : IEntityTypeConfiguration<ActivityEvent>
{
    public void Configure(EntityTypeBuilder<ActivityEvent> builder)
    {
        builder.Property(a => a.ActorId).IsRequired();
        builder.Property(a => a.ActivityType)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(a => a.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("getdate()");
        builder.HasOne(a => a.Actor)
            .WithMany(u => u.Activities)
            .HasForeignKey(a => a.ActorId);
    }
}