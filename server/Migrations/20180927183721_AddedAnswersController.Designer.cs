﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using suncoast_overflow;

namespace suncoast_overflow.Migrations
{
    [DbContext(typeof(SuncoastOverflowContext))]
    [Migration("20180927183721_AddedAnswersController")]
    partial class AddedAnswersController
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("suncoast_overflow.Models.Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Answered");

                    b.Property<string>("BodyOfAnswer");

                    b.Property<int>("DownVoteAnswer");

                    b.Property<int>("QuestionsId");

                    b.Property<int>("UpVoteAnswer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionsId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("suncoast_overflow.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Asked");

                    b.Property<string>("BodyOfQuestion");

                    b.Property<int>("DownVoteQuestion");

                    b.Property<string>("TitleOfQuestion");

                    b.Property<int>("UpVoteQuestion");

                    b.Property<string>("user");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("suncoast_overflow.Models.Answers", b =>
                {
                    b.HasOne("suncoast_overflow.Models.Questions", "Questions")
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
