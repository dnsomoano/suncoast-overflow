using System;

namespace suncoast_overflow.Models
{
    public class Questions
    {
        public int Id { get; set; }

        public string TitleOfQuestion { get; set; }

        public string BodyOfQuestion { get; set; }

        public int UpVoteQuestion { get; set; }
        public int DownVoteQuestion { get; set; }

        public string user { get; set; }

        public DateTime DateOfQuestion { get; set; } = DateTime.Now;
    }
}