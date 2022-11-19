using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLDR.Domain.Entities.QnA;

namespace TLDR.Infrastructure.Persistance.EntityConfigurations.QnA;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.Property(a => a.Description).IsRequired();
        builder.HasOne(a => a.Question).WithMany(q => q.Answers).HasForeignKey(a => a.QuestionId);
        builder.HasMany(a => a.FollowingQuestions).WithMany().UsingEntity<Dictionary<string, object>>(
            "AnswerFollowingQuestions",
            j => j
                .HasOne<Question>()
                .WithMany()
                .HasForeignKey("FollowingQuestionId")
                .HasConstraintName("FK_AnswerFollowingQuestions_FollowingQuestionId_Questions_Id")
                .OnDelete(DeleteBehavior.Restrict),
            j => j
                .HasOne<Answer>()
                .WithMany()
                .HasForeignKey("AnswerId")
                .HasConstraintName("FK_AnswerFollowingQuestions_AnswerId_Answers_Id")
                .OnDelete(DeleteBehavior.Restrict)
        );

        builder.HasData(new[]{
            new Answer{
                Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b"),
                Description = "You will get the next performance review in 6 months after your last review.",
                QuestionId = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b"),
            },
            new Answer{
                Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c"),
                Description = "You can get a raise by asking your manager for one.",
                QuestionId = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c"),
            },
            new Answer{
                Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d"),
                Description = "You can review the skill matrix of requirements on sharepoint <insert link here>",
                QuestionId = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d"),
            },
        });
    }
}