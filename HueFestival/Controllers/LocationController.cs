using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HueFestival.IRepositories;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepo;
        public LocationController(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocationViewModel_Add model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var AddLocationAsync = await _locationRepo.AddLocationAsync(model);

            return Ok(AddLocationAsync);
        }

    
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _locationRepo.GetLocationAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _locationRepo.DeleteLocationAsync(id);

            if (!result)
                return NotFound();

            return Ok("Xoá thành công");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, LocationViewModel_Add model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await _locationRepo.UpdateLocationAsync(id, model))
                return Ok("Xoá thành công");

            return BadRequest();
        }
    }
}
