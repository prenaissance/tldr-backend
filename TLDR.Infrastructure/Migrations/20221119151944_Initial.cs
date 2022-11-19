using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TLDR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerFollowingQuestions",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowingQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerFollowingQuestions", x => new { x.AnswerId, x.FollowingQuestionId });
                    table.ForeignKey(
                        name: "FK_AnswerFollowingQuestions_AnswerId_Answers_Id",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerFollowingQuestions_FollowingQuestionId_Questions_Id",
                        column: x => x.FollowingQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "Role", "Title" },
                values: new object[,]
                {
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b"), null, "ALL", "When will I get the next performance review?" },
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c"), null, "ALL", "How do I get a raise?" },
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d"), null, "DEVELOPER", "What are the requirements to be a senior software developer?" },
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4e"), null, "QA", "Why are the developers in my team writing buggy code?" },
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4f"), null, "MANAGEMENT", "How should I reward an outstanding developer in my team?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b"), "You will get the next performance review in 6 months after your last review.", new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4b") },
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c"), "You can get a raise by asking your manager for one.", new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4c") },
                    { new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d"), "You can review the skill matrix of requirements on sharepoint <insert link here>", new Guid("f1b5b1b0-5c1a-4b9f-8b9c-1b1b0b5c1a4d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerFollowingQuestions_FollowingQuestionId",
                table: "AnswerFollowingQuestions",
                column: "FollowingQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Title",
                table: "Questions",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerFollowingQuestions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
