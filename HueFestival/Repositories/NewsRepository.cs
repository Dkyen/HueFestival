using System;
using HueFestival.ViewModel;
using HueFestival.Data;
using HueFestival.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public NewsRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
       
        public async Task<int> AddNewsAsyn(NewsViewModel model)
        {
            var newNews = _mapper.Map<News>(model);
            _context.News!.Add(newNews);
            await _context.SaveChangesAsync();
            return newNews.NewsId;
        }
        public async Task DeleteNewsAsyn(int id)
        {
            var deleteNews = _context.News!.SingleOrDefault(b => b.NewsId == id);
            if (deleteNews != null)
            {
                _context.News!.Remove(deleteNews);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NewsViewModel>> GetAllNewsAsyn()
        {
            var news = await _context.News!.ToListAsync();
            return _mapper.Map<List<NewsViewModel>>(news);
        }

        public async Task<NewsViewModel> GetNewsAsyn(int id)
        {
            var news = await _context.News!.FindAsync(id);
            return _mapper.Map<NewsViewModel>(news);
        }

        public async Task UpdateNewsAsyn(int id, NewsViewModel model)
        {
            if (id == model.NewsId)
            {
                var updateNews = _mapper.Map<News>(model);
                _context.News!.Update(updateNews);
                await _context.SaveChangesAsync();


            }

        }
    }
}

