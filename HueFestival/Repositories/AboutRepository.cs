using System;
using HueFestival.ViewModel;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static QRCoder.PayloadGenerator.SwissQrCode;

namespace HueFestival.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public AboutRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task AddAsync(AboutViewModel_Add model)
        {
            var about = _mapper.Map<About>(model);
            _context.Abouts!.Add(about);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var about = await _context.Abouts!.FindAsync(id);

            if (about == null)
                return false;

            _context.Abouts!.Remove(about);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<AboutViewModel>> GetAllAsync()
        {
            var abouts = await _context.Abouts!.ToListAsync();
            return _mapper.Map<List<AboutViewModel>>(abouts);
        }

        public async Task<AboutViewModel_Details> GetDetailsAsync(int id)
        {
            var about = await _context.Abouts!.FindAsync(id);
            return _mapper.Map<AboutViewModel_Details>(about);
        }

        public async Task<bool> UpdateAsync(int id, AboutViewModel_Add input)
        {
            var about = await _context.Abouts!.FindAsync(id);

            if (about == null)
                return false;

            about.Title = input.Title;
            about.Content = input.Content;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}