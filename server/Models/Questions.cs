using System;
using System.Collections.Generic;

namespace suncoast_overflow.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string TitleOfQuestion { get; set; }
        public string BodyOfQuestion { get; set; }
        public int UpVoteQuestion { get; set; }
        public int DownVoteQuestion { get; set; }
        public DateTime DateOfQuestion { get; set; } = DateTime.Now;

        public virtual List<Answers> Answers { get; set; }
    }
}