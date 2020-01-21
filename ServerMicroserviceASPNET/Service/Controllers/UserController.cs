using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DataBase;
using Service.DataBase.Entities;
using System.Web;
using System.Net;
using Service.Model;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext db;
        public UserController()
        {
            db = new DatabaseContext();
        }


        [HttpGet]
        public ContentResult Index()
        {
            try
            {
                //var fileContents = System.IO.File.ReadAllText("C:/Users/razan/Desktop/SparkVisionBucketProject/MicroServiceASP.NET/ServerMicroserviceASPNET/Service/index.html");
                var fileContents = System.IO.File.ReadAllText("index.html");
                return new ContentResult
                {
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = fileContents
                };
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = "0"
                };
            }
        }

        [Route("post/{value}")]
        [HttpPost]
        [AcceptVerbs("POST")]
        public string Post(string value)
        {
            string[] numbersToProcess = value.Split("-");
            BucketRunner br = new BucketRunner(int.Parse(numbersToProcess[0]), int.Parse(numbersToProcess[1]), int.Parse(numbersToProcess[2]));
            string answer = br.run();
            if (br.detectTarget())
                return answer;
            else
                return "There is no way to measure " + numbersToProcess[2] + "by the given 2 Buckets!";
        }


        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,model);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            try
            {
     
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
