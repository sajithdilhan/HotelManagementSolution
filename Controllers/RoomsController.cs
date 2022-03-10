using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagementSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(ILogger<RoomsController> logger)
        {
            _logger = logger;
        }

        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoomsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
