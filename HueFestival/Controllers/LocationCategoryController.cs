using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueFestival.IRepositories;
using HueFestival.Repositories;
using HueFestival.ViewModel;
using AutoMapper;
using HueFestival.Data;
using Microsoft.AspNetCore.Mvc;


namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class LocationCategoryController : ControllerBase
    {
        private readonly ILocationCategoryRepository _locationCategoryRepo;

        public LocationCategoryController(ILocationCategoryRepository locationCategoryRepo)
        {
            _locationCategoryRepo = locationCategoryRepo;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocationCategoryViewModel_Add mode)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _locationCategoryRepo.AddAsync(mode);

            return Ok("Thêm thành công!");
        }


        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, LocationCategoryViewModel_Add model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await _locationCategoryRepo.UpdateAsync(id, model))
                return Ok("Cập nhật thành công");

            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _locationCategoryRepo.DeleteAsync(id))
                return Ok("Xoá thành công");

            return NotFound();
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _locationCategoryRepo.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _locationCategoryRepo.GetAllAsync());
    }
}


