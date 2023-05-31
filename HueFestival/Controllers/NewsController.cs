using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private static List<News> NewsList = new List<News>
        {
            new News { NewsId = 1, Title = "News 1", Content = "Noi dung 1", Image = "image1.jpg", CreatedAt = DateTime.Now },
            new News { NewsId = 2, Title = "News 2", Content = "Noi dung 2", Image = "image2.jpg", CreatedAt = DateTime.Now },
            // Thêm các dữ liệu tạm thời khác
        };

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(NewsList);
        }

        [HttpPost("Add")]
        public IActionResult Add(News news)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Tạo ID cho tin tức mới (có thể sử dụng các thuật toán phù hợp)
            news.NewsId = NewsList.Count + 1;
            news.CreatedAt = DateTime.Now;

            // Thêm tin tức vào danh sách tạm thời
            NewsList.Add(news);

            return Ok("Successfully");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var news = NewsList.Find(n => n.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            NewsList.Remove(news);

            return Ok("Delete Successfully");
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var news = NewsList.Find(n => n.NewsId == id);
            if (news != null)
            {
                return Ok(news);
            }

            return NotFound();
        }

        [HttpPut("Edit")]
        public IActionResult Edit(int id, News updatedNews)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var news = NewsList.Find(n => n.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            news.Title = updatedNews.Title;
            news.Content = updatedNews.Content;
            news.Image = updatedNews.Image;

            return Ok("Edit Successfully");
        }
    }

   
}
