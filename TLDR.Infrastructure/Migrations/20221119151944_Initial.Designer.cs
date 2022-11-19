﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TLDR.Infrastructure.Persistance;

#nullable disable

namespace TLDR.Infrastructure.Migrations
{
    [DbContext(typeof(TldrDbContext))]
    [Migration("20221119151944_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnswerFollowingQuestions", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowingQuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnswerId", "FollowingQuestionId");

                    b.HasIndex("FollowingQuestionId");

                    b.ToTable("AnswerFollowingQuestions");
                });

            modelBuilder.Entity("TLDR.Domain.Entities.Authentication.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TLDR.Domain.Entities.QnA.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b"),
                            Description = "You will get the next performance review in 6 months after your last review.",
                            QuestionId = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b")
                        },
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c"),
                            Description = "You can get a raise by asking your manager for one.",
                            QuestionId = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c")
                        },
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d"),
                            Description = "You can review the skill matrix of requirements on sharepoint <insert link here>",
                            QuestionId = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d")
                        });
                });

            modelBuilder.Entity("TLDR.Domain.Entities.QnA.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b"),
                            Role = "ALL",
                            Title = "When will I get the next performance review?"
                        },
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c"),
                            Role = "ALL",
                            Title = "How do I get a raise?"
                        },
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d"),
                            Role = "DEVELOPER",
                            Title = "What are the requirements to be a senior software developer?"
                        },
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4e"),
                            Role = "QA",
                            Title = "Why are the developers in my team writing buggy code?"
                        },
                        new
                        {
                            Id = new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4f"),
                            Role = "MANAGEMENT",
                            Title = "How should I reward an outstanding developer in my team?"
                        });
                });

            modelBuilder.Entity("AnswerFollowingQuestions", b =>
                {
                    b.HasOne("TLDR.Domain.Entities.QnA.Answer", null)
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_AnswerFollowingQuestions_AnswerId_Answers_Id");

                    b.HasOne("TLDR.Domain.Entities.QnA.Question", null)
                        .WithMany()
                        .HasForeignKey("FollowingQuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_AnswerFollowingQuestions_FollowingQuestionId_Questions_Id");
                });

            modelBuilder.Entity("TLDR.Domain.Entities.QnA.Answer", b =>
                {
                    b.HasOne("TLDR.Domain.Entities.QnA.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TLDR.Domain.Entities.QnA.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
