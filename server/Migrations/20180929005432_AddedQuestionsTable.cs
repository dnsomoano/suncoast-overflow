﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace suncoast_overflow.Migrations
{
    public partial class AddedQuestionsTable : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}