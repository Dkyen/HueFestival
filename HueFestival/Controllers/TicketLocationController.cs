using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLocationController : ControllerBase
    {
        private static List<TicketLocation> TicketLocationList = new List<TicketLocation>
        {
            new TicketLocation { TicketLocationId = 1, TicketLocationName = "Ticket Location 1", Address = "123 ABC Street", PhoneNumber = "1234567890", Image = "image1.jpg" },
            new TicketLocation { TicketLocationId = 2, TicketLocationName = "Ticket Location 2", Address = "456 XYZ Street", PhoneNumber = "0987654321", Image = "image2.jpg" }
            // Thêm các dữ liệu tạm thời khác
        };

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(TicketLocationList);
        }

        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            var ticketLocation = TicketLocationList.Find(t => t.TicketLocationId == id);
            if (ticketLocation != null)
            {
                return Ok(ticketLocation);
            }

            return NotFound();
        }

        [HttpPost("Add")]
        public IActionResult Add(TicketLocation ticketLocation)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            ticketLocation.TicketLocationId = TicketLocationList.Count + 1;

            // Thêm TicketLocation vào danh sách tạm thời
            TicketLocationList.Add(ticketLocation);

            // Trả về thông báo thành công
            return Ok("Successfully");
        }

        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, TicketLocation updatedTicketLocation)
        {
            var ticketLocation = TicketLocationList.Find(t => t.TicketLocationId == id);
            if (ticketLocation == null)
            {
                return NotFound();
            }

            ticketLocation.TicketLocationName = updatedTicketLocation.TicketLocationName;
            ticketLocation.Address = updatedTicketLocation.Address;
            ticketLocation.PhoneNumber = updatedTicketLocation.PhoneNumber;
            ticketLocation.Image = updatedTicketLocation.Image;

            // Trả về thông báo thành công
            return Ok("Successfully");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var ticketLocation = TicketLocationList.Find(t => t.TicketLocationId == id);
            if (ticketLocation == null)
            {
                return NotFound();
            }

            TicketLocationList.Remove(ticketLocation);

            // Trả về thông báo thành công
            return Ok("Successfully");
        }
    }
}
