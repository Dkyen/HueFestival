using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueFestival.Models;
using HueFestival.Data;
using HueFestival.Repositories;
using HueFestival.ViewModel;
using AutoMapper;

namespace HueFestival.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _aboutrepo;
        

        public AboutController(IAboutRepository repo)
        {
            _aboutrepo = repo;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AboutViewModel_Add mode)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _aboutrepo.AddAsync(mode);

            return Ok("Thêm thành công!");
        }
         
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _aboutrepo.DeleteAsync(id))
                return Ok("Xoá thành công");

            return BadRequest();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _aboutrepo.GetAllAsync());

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var result = await _aboutrepo.GetDetailsAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, AboutViewModel_Add input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await _aboutrepo.UpdateAsync(id, input))
                return Ok("Cập nhật thành công");

            return BadRequest();
        }
    }
}
    


