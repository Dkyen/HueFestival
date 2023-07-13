using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueFestival.Models;
using Microsoft.AspNetCore.Mvc;
using HueFestival.Data;
using HueFestival.IRepositories;
using HueFestival.Repositories;
using HueFestival.ViewModel;


namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLocationController : ControllerBase
    {
        private readonly ITicketLocationRepository _ticketlocationRepo;
        public TicketLocationController(ITicketLocationRepository ticketlocationRepo)
        {
            _ticketlocationRepo = ticketlocationRepo;

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
           => Ok(await _ticketlocationRepo.GetAllAsync());

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TicketLocationViewModel_Add model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _ticketlocationRepo.AddASync(model);

            return Ok("Thêm thành công");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _ticketlocationRepo.DeleteAsync(id))
                return Ok("Xoá thành công");

            return NotFound();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, TicketLocationViewModel_Add model)
        {
            if (await _ticketlocationRepo.UpdateAsync(id, model))
                return Ok("Cập nhật thành công");

            return BadRequest();
        }
    }
}
