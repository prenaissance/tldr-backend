using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLDR.Domain.Entities.Authentication.Enums;
using TLDR.Domain.Entities.QnA;

namespace TLDR.Infrastructure.Persistance.EntityConfigurations.QnA;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasIndex(q => q.Title).IsUnique();
        builder.Property(q => q.Title).IsRequired();
        builder.Property(q => q.Description).IsRequired(false);
        builder.HasMany(q => q.Answers).WithOne(a => a.Question).HasForeignKey(a => a.QuestionId);
        builder.Property(q => q.Role).IsRequired().HasConversion<string>();

        builder.HasData(
            new[]{
                new Question
                {
                    Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b"),
                    Title = "When will I get the next performance review?",
                    Role = Roles.ALL,
                },
                new Question
                {
                    Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c"),
                    Title = "How do I get a raise?",
                    Role = Roles.ALL,
                },
                new Question
                {
                    Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d"),
                    Title = "What are the requirements to be a senior software developer?",
                    Role = Roles.DEVELOPER,
                },
                new Question
                {
                    Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4e"),
                    Title = "Why are the developers in my team writing buggy code?",
                    Role = Roles.QA,
                },
                new Question
                {
                    Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4f"),
                    Title = "How should I reward an outstanding developer in my team?",
                    Role = Roles.MANAGEMENT,
                },
            }
        );
    }
}