using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class AboutController : Controller
    {
        private static List<string> AboutList = new List<string>
        {
            "About 1",
            "About 2"
            // Thêm các dữ liệu tạm thời khác
        };

        // GET: api/about
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(AboutList);
        }

        // GET api/about/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id >= 0 && id < AboutList.Count)
            {
                return Ok(AboutList[id]);
            }

            return NotFound();
        }

        // POST api/about
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AboutList.Add(value);
                return Ok("Successfully");
            }

            return BadRequest();
        }

        // PUT api/about/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id >= 0 && id < AboutList.Count && !string.IsNullOrEmpty(value))
            {
                AboutList[id] = value;
                return Ok("Successfully");
            }

            return NotFound();
        }

        // DELETE api/about/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= 0 && id < AboutList.Count)
            {
                AboutList.RemoveAt(id);
                return Ok("Successfully");
            }

            return NotFound();
        }
    }
}
