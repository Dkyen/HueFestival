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


        [HttpGet]
        public async Task<IActionResult> GetAllNewsAsyn()
        {
            try
            {
                return Ok(await _newsrepo.GetAllNewsAsyn());

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await _newsrepo.GetNewsAsyn(id);

            if (news == null)
            {
                return NotFound();
            }

            return Ok( news);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewAbout(NewsViewModel model)
        {
            try
            {

                var newNewsId = await _newsrepo.AddNewsAsyn(model);
                var news = await _newsrepo.GetNewsAsyn(newNewsId);
                return news == null ? NotFound() : Ok(news);

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(int id, NewsViewModel model)
        {
            if (id != model.NewsId)
            {
                return NotFound();
            }
            await _newsrepo.UpdateNewsAsyn(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews([FromRoute] int id)
        {
            await _newsrepo.DeleteNewsAsyn(id);
            return Ok();

        }

    }
}
