using System;

namespace suncoast_overflow.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public string BodyOfAnswer { get; set; }
        public int UpVoteAnswer { get; set; }
        public int DownVoteAnswer { get; set; }
        public DateTime Answered { get; set; } = DateTime.Now;
        public int QuestionsId { get; set; }
        public virtual Questions Questions { get; set; }

    }
}