using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HueFestival.Repositories;
using HueFestival.ViewModel;
using AutoMapper;

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepo;

        public EventController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        [HttpGet("get_show_sales_ticket")]
        public async Task<IActionResult> GetShowSalesTicket()
             => Ok(await _eventRepo.GetListShowSalesTicketAsync());

       
        [HttpPost("add")]
        public async Task<IActionResult> Add(EventViewModel_Add model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = await _eventRepo.AddAsync(model);

            switch (result)
            {
                case 1:
                    return NotFound(new { Success = false, Message = "Location, program or location category not found" });
                case 2:
                    return Problem();
                case 3:
                    return Ok("Thêm thành công");
                default:
                    return NoContent();
            }
        }

        [HttpGet("get_calendar_list")]
        public async Task<IActionResult> GetCalendarList()
            => Ok(await _eventRepo.GetCalendarList());

        [HttpGet("get_by_date")]
        public async Task<IActionResult> GetByDate(DateTime date)
            => Ok(await _eventRepo.GetByDate(date));

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventRepo.DeleteAsync(id);

            switch (result)
            {
                case 1:
                    return NotFound();
                case 2:
                    return Problem();
                case 3:
                    return Ok("Xoá thành công");
                default:
                    return NoContent();
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(int id, EventViewModel_Add model)
        {
            var result = await _eventRepo.UpdateAsync(id, model);

            switch (result)
            {
                case 1:
                    return NotFound();
                case 2:
                    return Problem();
                case 3:
                    return Ok("Cập nhật thành công");
                default:
                    return NoContent();
            }
        }

        [HttpGet("get_details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var show = await _eventRepo.GetDetailsAsync(id);

            if (show != null)
                return Ok(show);

            return NotFound();
        }

        [HttpGet("get_show_list")]
        public async Task<IActionResult> GetListShowSalesTicketAsync()
            => Ok(await _eventRepo.GetListShowSalesTicketAsync());
    }
}

