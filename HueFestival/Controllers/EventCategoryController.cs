using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueFestival.IRepositories;
using AutoMapper;
using HueFestival.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class EventCategoryController : ControllerBase
    {
        private readonly IEventCategoryRepository _eventCategoryRepo;
        public EventCategoryController(IEventCategoryRepository eventCategoryRepo)
        {
            _eventCategoryRepo = eventCategoryRepo;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(EventCategoryViewModel_Add model)
        {
            var result = await _eventCategoryRepo.AddAsync(model);

            switch (result)
            {
                case 1:
                    return Problem();
                case 2:
                    return Ok("Thêm thành công");
                default:
                    return NoContent();
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _eventCategoryRepo.GetAllAsync());

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventCategoryRepo.DeleteAsync(id);

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

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, EventCategoryViewModel_Add model)
        {
            var result = await _eventCategoryRepo.UpdateAsync(id, model);

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
    }
}

