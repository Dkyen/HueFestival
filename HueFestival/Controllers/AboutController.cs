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
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _aboutrepo;

        public AboutController(IAboutRepository repo)
        {
            _aboutrepo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAbouts()
        {
            try
            {
                return Ok(await _aboutrepo.GetAllAboutsAsyn());

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var about = await _aboutrepo.GetAboutsAsyn(id);

            if (about == null)
            {
                return NotFound();
            }

            return Ok(about);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewAbout(AboutViewModel model)
        {
            try {

                var newAboutId = await _aboutrepo.AddAboutAsyn(model);
                var about = await _aboutrepo.GetAboutsAsyn(newAboutId);
                return about == null ? NotFound() : Ok(about);

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(int id, AboutViewModel model)
        {
            if(id != model.AboutId)
            {
                return NotFound();
            }
            await _aboutrepo.UpdateAboutAsyn(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout([FromRoute] int id)
        {
            await _aboutrepo.DeleteAboutsAsyn(id);
            return Ok();

        }

    }
}
