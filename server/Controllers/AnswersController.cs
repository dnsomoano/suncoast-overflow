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

        // GET api/answers
        [HttpGet]
        public ActionResult<IEnumerable<Answers>> Get()
        {
            return this.db.Answers;
        }

        // MUST match answers.id
        // GET api/answers/{id}
        [HttpGet("{id}")]
        public ActionResult<Answers> Get(int id)
        {
            return this.db.Answers.FirstOrDefault(f => f.Id == id);
        }// END

        // POST api/answers/{id}
        [HttpPost("{id}")]
        public Answers Post(int id, [FromBody] Answers answer)
        {
            answer.QuestionsId = id;
            this.db.Answers.Add(answer);
            this.db.SaveChanges();
            return answer;
        }// END

        // MUST use answers.Id NOT questionsId!
        // PATCH api/answers/{vote}/{id}/
        [HttpPatch("{vote}/{id}")]
        public Answers UpVote(string vote, int id)
        {
            // Declare a reference to for db answers to find id
            var answer = this.db.Answers.FirstOrDefault(f => f.Id == id);
            if (vote == "up")
            {
                // Add 1 to upVote
                answer.UpVoteAnswer++;
            }
            else
            {
                // Add 1 to downVote
                answer.DownVoteAnswer++;
            }
            this.db.SaveChanges();
            return answer;
        }// END

        // DELETE api/answers/{id}
        [HttpDelete("{id}")]
        public Answers Delete(int id)
        {
            var answer = this.db.Answers.FirstOrDefault(f => f.Id == id);
            this.db.Answers.Remove(answer);
            this.db.SaveChanges();
            return answer;
        }// END
    }
}