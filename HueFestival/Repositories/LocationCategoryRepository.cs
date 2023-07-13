using System;
using HueFestival.IRepositories;
using AutoMapper;
using HueFestival.ViewModel;
using HueFestival.Data;
using Microsoft.EntityFrameworkCore;
using HueFestival.Models;

namespace HueFestival.Repositories
{
	public class LocationCategoryRepository :ILocationCategoryRepository
	{
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public LocationCategoryRepository(HueFestivalContext context, IMapper mapper)
		{
            _context = context;
            _mapper = mapper;
        }

        
        public async Task AddAsync(LocationCategoryViewModel_Add model)
        {
            var locationCategory = _mapper.Map<LocationCategory>(model);
            _context.LocationCategories!.Add(locationCategory);
            await _context.SaveChangesAsync();
        }
       



        public async Task<bool> CheckExistAsync(int id)
        {
            return await _context.LocationCategories!.AnyAsync(lc => lc.LocationCategoryId == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var locationCategory = await _context.LocationCategories!.FindAsync(id);

            if (locationCategory is null)
                return false;

            _context.LocationCategories.Remove(locationCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<LocationCategoryViewModel>> GetAllAsync()
        {
            var locationCategories = await _context.LocationCategories!.ToListAsync();
            return _mapper.Map<List<LocationCategoryViewModel>>(locationCategories);
        }


        public async Task<bool> UpdateAsync(int id, LocationCategoryViewModel_Add model)
        {
            var locationCategory = await _context.LocationCategories!.FindAsync(id);

            if (locationCategory is null)
                return false;

            locationCategory.Title = model.Title;
            locationCategory.Image = model.Image;

            await _context.SaveChangesAsync();

            return true;
        }
        

        public async Task<LocationCategoryViewModel_Details> GetByIdAsync(int id)
        {
            var locationCategory = await _context.LocationCategories!.FindAsync(id);

            if (locationCategory == null)
                return null!;

            await _context.Entry(locationCategory)
                .Collection(lc => lc.ListLocation!)
                .LoadAsync();

            return _mapper.Map<LocationCategoryViewModel_Details>(locationCategory);

        }

        public async Task<LocationCategory?> GetById(int id)
        {
            return await _context.LocationCategories!
                .Include(lc => lc.ListLocation)
                .SingleOrDefaultAsync(lc => lc.LocationCategoryId == id);
        }



    }
}

