using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace suncoast_overflow.Migrations
{
    public partial class AddedSeededDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    User = table.Column<string>(nullable: true),
                    TitleOfQuestion = table.Column<string>(nullable: true),
                    BodyOfQuestion = table.Column<string>(nullable: true),
                    UpVoteQuestion = table.Column<int>(nullable: false),
                    DownVoteQuestion = table.Column<int>(nullable: false),
                    DateOfQuestion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    User = table.Column<string>(nullable: true),
                    BodyOfAnswer = table.Column<string>(nullable: true),
                    UpVoteAnswer = table.Column<int>(nullable: false),
                    DownVoteAnswer = table.Column<int>(nullable: false),
                    DateOfAnswer = table.Column<DateTime>(nullable: false),
                    QuestionsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "BodyOfQuestion", "DateOfQuestion", "DownVoteQuestion", "TitleOfQuestion", "UpVoteQuestion", "User" },
                values: new object[] { 1, "what is the difference between an argument and perimeter? Both seem to be the same", new DateTime(2018, 10, 22, 11, 53, 8, 787, DateTimeKind.Local), 0, "difference between an argument and perimeter?", 1, "jackie-jaw" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "BodyOfQuestion", "DateOfQuestion", "DownVoteQuestion", "TitleOfQuestion", "UpVoteQuestion", "User" },
                values: new object[] { 2, "what is the difference between a static method and an instance method? Both seem to be the same", new DateTime(2018, 10, 22, 11, 53, 8, 788, DateTimeKind.Local), 0, "difference between a static method and an instance method?", 1, "jackie-job" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "BodyOfAnswer", "DateOfAnswer", "DownVoteAnswer", "QuestionsId", "UpVoteAnswer", "User" },
                values: new object[] { 3, "A perimeter actually ends..", new DateTime(2018, 10, 22, 11, 53, 8, 789, DateTimeKind.Local), 1, 1, 0, "jabberjaw" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "BodyOfAnswer", "DateOfAnswer", "DownVoteAnswer", "QuestionsId", "UpVoteAnswer", "User" },
                values: new object[] { 4, "A perimeter is declared within the function, while an argument is within the function call.", new DateTime(2018, 10, 22, 11, 53, 8, 789, DateTimeKind.Local), 0, 1, 3, "FTW" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsId",
                table: "Answers",
                column: "QuestionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
