using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndresAlarcon.TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskBoardController : ControllerBase
    {
        // GET: api/<TaskBoardController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TaskBoardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaskBoardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskBoardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskBoardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
