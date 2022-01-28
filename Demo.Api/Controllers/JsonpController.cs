using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Demo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonpController : ControllerBase
    {
        public JsonpController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get(string callback)
        {
            return new JsonpResult(new List<Student>
            {
                new Student
                {
                    Id = "1",
                    Name = "任哥"
                },
                new Student
                {
                    Id = "2",
                    Name = "Jill"
                },
                new Student
                {
                    Id = "3",
                    Name = "Articor"
                },
                new Student
                {
                    Id = "4",
                    Name = "Hugo"
                },
                new Student
                {
                    Id = "5",
                    Name = "Wesker"
                },
            });
        }
    }
}