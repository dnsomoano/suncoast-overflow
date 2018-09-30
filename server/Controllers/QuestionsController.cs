using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // public class QuestionModel
        // {
        //     public string title { get; set; }
        //     public string user { get; set; }
        //     public string body { get; set; }
        // }

        // GET api/questions
        [HttpGet]
        public IEnumerable<Questions> Get()
        {
            return this.db.Questions.Include(i => i.Answers);
        }

        // GET api/questions/{id}
        [HttpGet("{id}")]
        public ActionResult<Questions> Get(int id)
        {
            return this.db.Questions.Include(i => i.Answers).FirstOrDefault(f => f.Id == id);
        }

        // POST api/questions
        [HttpPost]
        public Questions Post([FromBody] Questions question)
        {
            // var question = new Questions
            // {
            //     TitleOfQuestion = data.title.ToLower(),
            //     User = data.user.ToLower(),
            //     BodyOfQuestion = data.body.ToLower(),

            // };
            this.db.Questions.Add(question);
            this.db.SaveChanges();
            return question;
        }

        // As a user I should be able to up/down vote a question
        // PATCH api/questions/{id}/up-vote
        [HttpPatch("up/{id}")]
        public Questions upVote(int id)
        {
            // Declare a reference to for db Questions to find id
            var question = this.db.Questions.FirstOrDefault(f => f.Id == id);
            // Add 1 to upVote
            question.UpVoteQuestion++;
            this.db.SaveChanges();
            return question;
        }

        // PATCH api/questions/{id}
        [HttpPatch("down/{id}")]
        public Questions DownVote(int id)
        {
            // Declare a reference to for db Questions to find id
            var question = this.db.Questions.FirstOrDefault(f => f.Id == id);
            // Add 1 to upVote
            question.DownVoteQuestion++;
            this.db.SaveChanges();
            return question;
        }

        // DELETE api/questions/{id}
        [HttpDelete("{id}")]
        public Questions Delete(int id)
        {
            var question = this.db.Questions.FirstOrDefault(f => f.Id == id);
            this.db.Questions.Remove(question);
            this.db.SaveChanges();
            return question;
        }
    }
}