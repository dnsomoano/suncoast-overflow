using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using suncoast_overflow.Models;

namespace suncoast_overflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        public SuncoastOverflowContext db { get; set; }

        public QuestionsController()
        {
            this.db = new SuncoastOverflowContext();
        }

        public class QuestionModel
        {
            public string title { get; set; }
            public string body { get; set; }
        }
        // GET api/questions
        [HttpGet]
        public ActionResult<IEnumerable<Questions>> Get()
        {
            return this.db.Questions;
        }

        // POST api/questions
        [HttpPost]
        public ActionResult<Questions> Post([FromBody] QuestionModel data)
        {
            var question = new Questions
            {
                TitleOfQuestion = data.title.ToLower(),
                BodyOfQuestion = data.body,
            };
            this.db.Questions.Add(question);
            this.db.SaveChanges();
            return question;
        }

        // As a user I should be able to up/down vote a question
        // PATCH api/questions/{id}/up-vote
        [HttpPatch("{id}")]
        public Questions Patch(int id)
        {
            // Declare a reference to for db Questions to find id
            var question = this.db.Questions.FirstOrDefault(f => f.Id == id);
            // Add 1 to upVote
            question.UpVoteQuestion++;
            this.db.SaveChanges();
            return question;
        }
        // PATCH api/questions/{id}
        // [HttpPatch("{id}/down-vote")]
        // public Questions Patch(int id)
        // {
        //     // Declare a reference to for db Questions to find id
        //     var question = this.db.Questions.FirstOrDefault(f => f.Id == id);
        //     // Add 1 to upVote
        //     question.UpVoteQuestion--;
        //     this.db.SaveChanges();
        //     return question;
        // }
    }
}