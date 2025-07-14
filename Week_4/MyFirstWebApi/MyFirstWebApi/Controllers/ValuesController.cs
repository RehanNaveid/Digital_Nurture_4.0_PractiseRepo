using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // Static in-memory list to store posted values
        private static List<string> _values = new List<string> { "value1", "value2" };

        // READ: GET /api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_values);
        }

        // WRITE: POST /api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            _values.Add(value);
            return Created("", $"Added: {value}");
        }
    }
}
