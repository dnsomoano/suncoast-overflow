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

        // GET api/questions
        [HttpGet]
        public IEnumerable<Questions> Get()
        {
            return this.db.Questions.Include(i => i.Answers);
        }// END

        // GET api/questions/{id}
        [HttpGet("{id}")]
        public ActionResult<Questions> Get(int id)
        {
            return this.db.Questions.Include(i => i.Answers).FirstOrDefault(f => f.Id == id);
        }// END

        // POST api/questions
        [HttpPost]
        public Questions Post([FromBody] Questions question)
        {
            this.db.Questions.Add(question);
            this.db.SaveChanges();
            return question;
        }// END

        // PATCH api/questions/{vote}/{id}
        [HttpPatch("{vote}/{id}")]
        public Questions Patch(string vote, int id)
        {
            // Declare a reference to for db Questions to find id
            var question = this.db.Questions.FirstOrDefault(f => f.Id == id);
            if (vote == "up")
            {
                // Add 1 to upVote
                question.UpVoteQuestion++;
            }
            else
            {
                // Add 1 to downVote
                question.DownVoteQuestion++;
            }
            this.db.SaveChanges();
            return question;
        }// END

        // DELETE api/questions/{id}
        [HttpDelete("{id}")]
        public Questions Delete(int id)
        {
            var question = this.db.Questions.FirstOrDefault(f => f.Id == id);
            this.db.Questions.Remove(question);
            this.db.SaveChanges();
            return question;
        }// END
    }
}