using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueFestival.Models;
using HueFestival.Data;
using HueFestival.Repositories;
using HueFestival.ViewModel;
namespace HueFestival.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsrepo;

        public NewsController(INewsRepository repo)
        {
            _newsrepo = repo;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(NewsViewModel_Add mode)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _newsrepo.AddAsync(mode);

            return Ok("Thêm thành công");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _newsrepo.DeleteAsync(id))
                return Ok("Xoá thành công");

            return BadRequest();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _newsrepo.GetAllAsync());

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var result = await _newsrepo.GetDetailsAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, NewsViewModel_Add mode)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await _newsrepo.UpdateAsync(id, mode))
                return Ok("Cập nhật thành công");

            return BadRequest();
        }



    }
}
