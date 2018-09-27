using Microsoft.EntityFrameworkCore.Migrations;

namespace suncoast_overflow.Migrations
{
    public partial class AddedAnswersController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfQuestion",
                table: "Questions",
                newName: "Asked");

            migrationBuilder.RenameColumn(
                name: "DateOfAnswer",
                table: "Answers",
                newName: "Answered");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Asked",
                table: "Questions",
                newName: "DateOfQuestion");

            migrationBuilder.RenameColumn(
                name: "Answered",
                table: "Answers",
                newName: "DateOfAnswer");
        }
    }
}
