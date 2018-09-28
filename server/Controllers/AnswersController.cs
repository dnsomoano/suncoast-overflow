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
    public class AnswersController : ControllerBase
    {
        public SuncoastOverflowContext db { get; set; }

        public AnswersController()
        {
            this.db = new SuncoastOverflowContext();
        }

        public class AnswerModel
        {
            public string body { get; set; }
        }

        // GET api/answers
        [HttpGet]
        public ActionResult<IEnumerable<Answers>> Get()
        {
            return this.db.Answers;
        }

        // TODO fix -- returns 500
        // GET api/answers/{id}
        [HttpGet("{id}")]
        public ActionResult<Answers> Get(int id)
        {
            return this.db.Answers.FirstOrDefault(f => f.Id == id);
        }

        // POST api/answers/{id}
        [HttpPost("{id}")]
        public ActionResult<Answers> Post(int id, [FromBody] AnswerModel data)
        {
            var answer = new Answers
            {
                BodyOfAnswer = data.body.ToLower(),
                QuestionsId = id
            };
            this.db.Answers.Add(answer);
            this.db.SaveChanges();
            return answer;
        }

        // MUST use answers.Id NOT questionsId!
        // PATCH api/answers/up/{id}/
        [HttpPatch("up/{id}")]
        public Answers UpVote(int id)
        {
            // Declare a reference to for db answers to find id
            var answer = this.db.Answers.FirstOrDefault(f => f.Id == id);
            // Add 1 to upVote
            answer.UpVoteAnswer++;
            this.db.SaveChanges();
            return answer;
        }

        // MUST use answers.Id NOT questionsId!
        // PATCH api/answers/down/{id}
        [HttpPatch("down/{id}")]
        public Answers DownVote(int id)
        {
            // Declare a reference to for db answers to find id
            var answer = this.db.Answers.FirstOrDefault(f => f.Id == id);
            // Add 1 to upVote
            answer.DownVoteAnswer--;
            this.db.SaveChanges();
            return answer;
        }

        // DELETE api/answers/{id}
        [HttpDelete("{id}")]
        public Answers Delete(int id)
        {
            var answer = this.db.Answers.FirstOrDefault(f => f.Id == id);
            this.db.Answers.Remove(answer);
            this.db.SaveChanges();
            return answer;
        }
    }
}