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
    public class SearchController : ControllerBase
    {
        public SuncoastOverflowContext db { get; set; }

        public SearchController()
        {
            this.db = new SuncoastOverflowContext();
        }

        // GET api/search?q={title}
        [HttpGet]
        public IEnumerable<Questions> Get([FromQuery] string q)
        {
            var questionResults = this.db
                .Questions
                .Where(f => f.TitleOfQuestion.Contains(q) || f.BodyOfQuestion.Contains(q) || f.User.Contains(q))
                .OrderByDescending(o => o.UpVoteQuestion);
            return questionResults;
        }// END
    }
}