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
        // GET api/questions
        [HttpGet]
        public ActionResult<IEnumerable<Questions>> Get()
        {
            return this.db.Questions;
        }

        // POST api/questions
        [HttpPost]
        public ActionResult<Questions> Post([FromBody] string title, string body)
        {
            var question = new Questions
            {
                TitleOfQuestion = title,
                BodyOfQuestion = body,
            };
            this.db.Questions.Add(question);
            this.db.SaveChanges();
            return question;
        }

        // As a user I should be able to up/down vote a question
        // PATCH api/questions
        // [HttpPatch("{title}")]
        // public ActionResult<Questions> Patch(string title) {
        //     var UpdateToAnimal = this.db.Questions.FirstOrDefault(f => f.TitleOfQuestion.Contains(title));
        // }
    }
}