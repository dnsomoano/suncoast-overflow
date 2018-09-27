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
                optionsBuilder.UseNpgsql("server=localhost;username=postgres;password=mark;database=SuncoastOverflow");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
    }
}
