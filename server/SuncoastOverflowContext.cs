using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using suncoast_overflow.Models;


namespace suncoast_overflow
{
    public partial class SuncoastOverflowContext : DbContext
    {
        public SuncoastOverflowContext()
        {
        }

        public SuncoastOverflowContext(DbContextOptions<SuncoastOverflowContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("server=localhost;username=postgres;password=k2#tgl38r9;database=SuncoastOverflow");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>().HasData(
                new Questions
                {
                    Id = 1,
                    User = "jackie-jaw",
                    TitleOfQuestion = "difference between an argument and perimeter?",
                    BodyOfQuestion = "what is the difference between an argument and perimeter? Both seem to be the same",
                    UpVoteQuestion = 1,
                    DownVoteQuestion = 0

                },
                new Questions
                {
                    Id = 2,
                    User = "jackie-job",
                    TitleOfQuestion = "difference between a static method and an instance method?",
                    BodyOfQuestion = "what is the difference between a static method and an instance method? Both seem to be the same",
                    UpVoteQuestion = 1,
                    DownVoteQuestion = 0

                }

            );
            modelBuilder.Entity<Answers>().HasData(
                new Answers
                {
                    Id = 3,
                    User = "jabberjaw",
                    BodyOfAnswer = "A perimeter actually ends..",
                    UpVoteAnswer = 0,
                    DownVoteAnswer = 1,
                    QuestionsId = 1,

                },
                new Answers
                {
                    Id = 4,
                    User = "FTW",
                    BodyOfAnswer = "A perimeter is declared within the function, while an argument is within the function call.",
                    UpVoteAnswer = 3,
                    DownVoteAnswer = 0,
                    QuestionsId = 1,

                }
            );
        }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
    }
}
