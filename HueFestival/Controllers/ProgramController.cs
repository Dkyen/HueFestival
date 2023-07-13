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
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _programRepo;

        public ProgramController(IProgramRepository programRepo)
        {
            _programRepo = programRepo;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProgramViewModel_Add model)
        {
            await _programRepo.AddAsync(model);

            return Ok("Thêm thành công");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _programRepo.DeleteAsync(id);

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

        [HttpGet("TieuDiem")]
        public async Task<IActionResult> GetAllTieuDiem()
            => Ok(await _programRepo.GetAllByTypeProgram(1));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _programRepo.GetAllAsync());

        [HttpGet("CongDong")]
        public async Task<IActionResult> GetAllCongDong()
            => Ok(await _programRepo.GetAllByTypeProgram(3));

        [HttpGet("Details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var result = await _programRepo.GetDetailsAsync(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, ProgramViewModel_Add model)
        {
            var result = await _programRepo.UpdateAsync(id, model);

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



        


       

       
       

   