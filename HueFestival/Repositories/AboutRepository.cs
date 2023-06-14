using System;
using HueFestival.ViewModel;
using HueFestival.Data;
using HueFestival.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> AddAboutAsyn(AboutViewModel model)
        {
            var newAbout = _mapper.Map<About>(model);
            _context.Abouts!.Add(newAbout);
            await _context.SaveChangesAsync();
            return newAbout.AboutId;
        }

        public async Task DeleteAboutsAsyn(int id)
        {
            var deleteAbout = _context.Abouts!.SingleOrDefault(b => b.AboutId == id);
            if (deleteAbout != null)
            {
                _context.Abouts!.Remove(deleteAbout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AboutViewModel>> GetAllAboutsAsyn()
        {
            var abouts = await _context.Abouts!.ToListAsync();
            return _mapper.Map<List<AboutViewModel>>(abouts);
        }

        public async Task<AboutViewModel> GetAboutsAsyn(int id)
        {
            var about = await _context.Abouts!.FindAsync(id);
            return _mapper.Map<AboutViewModel>(about);
        }

        public async Task UpdateAboutAsyn (int id, AboutViewModel model)
        {
            if (id == model.AboutId)
            {
                var updateAbout = _mapper.Map<About>(model);
                _context.Abouts!.Update(updateAbout);
                await _context.SaveChangesAsync();


            }

        }

        
    }

}