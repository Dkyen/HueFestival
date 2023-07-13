using System;
using AutoMapper;
using HueFestival.ViewModel;
using HueFestival.Data;
using HueFestival.IRepositories;
using HueFestival.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class EventCategoryRepository : IEventCategoryRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public EventCategoryRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task <int> AddAsync(EventCategoryViewModel_Add model)
        {
            try
            {
                var eventCategory = _mapper.Map<EventCategory>(model);

                _context.EventCategories!.Add(eventCategory);
                await _context.SaveChangesAsync();

                return 2;
            }
            catch
            {
                return 1;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var eventCategory = await _context.Set<EventCategory>().FindAsync(id);

                if (eventCategory is null)
                    return 1;

                _context.EventCategories!.Remove(eventCategory);
                await _context.SaveChangesAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public async Task<List<EventCategoryViewModel>> GetAllAsync()
        {
            
            var eventCategory = await _context.EventCategories!.ToListAsync();
            return _mapper.Map<List<EventCategoryViewModel>>(eventCategory);

        }

        public async Task<int> UpdateAsync(int id, EventCategoryViewModel_Add model)
        {
            try
            {
                var eventCategory = await _context.EventCategories!.FindAsync(id);

                if (eventCategory is null)
                    return 1;

                eventCategory.EventName = model.EventName;
                eventCategory.Content = model.Content;

                await _context.SaveChangesAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }
    }
}