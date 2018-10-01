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

        public class ResponseObject
        {
            public bool WasSuccessful { get; set; }
            public Object result { get; set; }
        }

        // GET api/search?q={title}
        [HttpGet]
        public ActionResult<ResponseObject> Get([FromQuery] string q)
        {
            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                result = this.db
                .Questions
                .Where(f => f.TitleOfQuestion.Contains(q) || f.BodyOfQuestion.Contains(q))
                .OrderBy(o => o.TitleOfQuestion),
            };
            if (q != null)
            {
                return _rv;
            }
            else
            {
                _rv.WasSuccessful = false;
                _rv.result = "Question not found";
                return _rv;
            }
        }
    }
}