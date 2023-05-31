using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private static List<Program> ProgramList = new List<Program>
        {
            new Program { ProgramId = 1, ProgramName = "Program 1", Content = "Chuong trinh 1", TypeProgram = 1 },
            new Program { ProgramId = 2, ProgramName = "Program 2", Content = "Chuong trinh 2", TypeProgram = 2 },
            // Thêm các dữ liệu tạm thời khác
        };

        [HttpPost("Add")]
        public IActionResult Add(Program program)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            program.ProgramId = ProgramList.Count + 1;

            // Thêm chương trình vào danh sách tạm thời
            ProgramList.Add(program);

            // Trả về thông báo thành công
            return Ok("Successfully");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var program = ProgramList.Find(p => p.ProgramId == id);
            if (program == null)
            {
                return NotFound();
            }

            ProgramList.Remove(program);

            // Trả về thông báo thành công
            return Ok("Successfully");
        }

        [HttpGet("TieuDiem")]
        public IActionResult GetAllTieuDiem()
        {
            var tieuDiemPrograms = ProgramList.FindAll(p => p.TypeProgram == 1);
            return Ok(tieuDiemPrograms);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(ProgramList);
        }

        [HttpGet("CongDong")]
        public IActionResult GetAllCongDong()
        {
            var congDongPrograms = ProgramList.FindAll(p => p.TypeProgram == 3);
            return Ok(congDongPrograms);
        }

        [HttpGet("Details")]
        public IActionResult GetDetails(int id)
        {
            var program = ProgramList.Find(p => p.ProgramId == id);
            if (program != null)
            {
                return Ok(program);
            }

            return NotFound();
        }

        [HttpPut("Edit")]
        public IActionResult Edit(int id, Program updatedProgram)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var program = ProgramList.Find(p => p.ProgramId == id);
            if (program == null)
            {
                return NotFound();
            }

            program.ProgramName = updatedProgram.ProgramName;
            program.Content = updatedProgram.Content;
            program.TypeProgram = updatedProgram.TypeProgram;

            // Trả về thông báo thành công
            return Ok("Successfully");
        }
    }

    
}
