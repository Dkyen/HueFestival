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

        public async Task AddAsync(NewsViewModel_Add model)
        {
            var news = _mapper.Map<News>(model);
            _context.News!.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var news = await _context.News!.FindAsync(id);

            if (news == null)
                return false;

            _context.News!.Remove(news);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<NewsViewModel>> GetAllAsync()
        {
            var news = await _context.News!.ToListAsync();
            return _mapper.Map<List<NewsViewModel>>(news);
        }

        public async Task<NewsViewModel_Details> GetDetailsAsync(int id)
        {
            var news = await _context.News!.FindAsync(id);
            return _mapper.Map<NewsViewModel_Details>(news);
        }

        public async Task<bool> UpdateAsync(int id, NewsViewModel_Add mode)
        {
            var news = await _context.News!.FindAsync(id);

            if (news == null)
                return false;

            news.Title = mode.Title;
            news.Content = mode.Content;
            news.Image = mode.Image;
            news.CreatedAt = mode.CreatedAt;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

