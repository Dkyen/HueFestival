using System;
using AutoMapper;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public EventRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(EventViewModel_Add model)
        {
            try
            {
                var programmeExist = await _context.Programmes!
                    .AnyAsync(p => p.ProgramId == model.ProgramId);

                var locationExist = await _context.Locations!
                    .AnyAsync(l => l.LocationId == model.LocationId);

                var eventCategoryExist = await _context.EventCategories!
                    .AnyAsync(sc => sc.EventCategoryId == model.EventCategoryId);

                if (!programmeExist || !locationExist || !eventCategoryExist)
                    return 1;

                var events = _mapper.Map<Event>(model);
                _context.Events!.Add(events);
                await _context.SaveChangesAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var @event = await _context.Events!.FindAsync(id);

                if (@event == null)
                    return 1;

                _context.Events.Remove(@event);
                await _context.SaveChangesAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public async  Task<List<EventViewModel>> GetAllAsync()
        {
            var events = await _context.Events!.Include(x => x.Location).Include(x => x.Programme).ToListAsync();
            return _mapper.Map<List<EventViewModel>>(events);
        }

        public async Task<List<EventViewModel>> GetByDate(DateTime date)
        {
            /* var events = await _context.Events!.Include(x =>x.EventCategory).Include(x => x.Location).Include(x => x.ProgramId)
                                     .Where(x => x.StartDate.Date == date.Date).ToListAsync();
              return _mapper.Map<List<EventViewModel>>(events);*/
            var events = await _context.Events!
         .Include(x => x.Programme)
         .Include(x => x.Location)
         .Where(x => x.StartDate.Date == date.Date)
         .ToListAsync();

            var eventViewModels = events.Select(e => new EventViewModel
            {
                EventId = e.EventId,
                ProgramId = e.ProgramId,
                ProgramName = e.Programme?.ProgramName,
                Type_inoff = e.Programme?.Type_inoff ?? 0,
                Time = $"{e.StartDate.ToString("HH:mm")} - {e.EndDate.ToString("HH:mm")}",
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                LocationId = e.LocationId,
                LocationTitle = e.Location?.Title
            }).ToList();

            return eventViewModels;

        }

        public async Task<IEnumerable<dynamic>> GetCalendarList()
        {
            var calendarList = await _context.Events!.GroupBy(x => x.StartDate.Date)
                                           .Select(x => new { Date = x.Key, CountShow = x.Count() })
                                           .ToListAsync();
            return calendarList;
        }

        public async Task<EventViewModel_Details> GetDetailsAsync(int id)
        {
            var @event = await _context.Events!
        .Where(e => e.EventId == id)
        .Include(e=>e.EventCategory)
        .Include(e => e.Programme)
        .Include(e => e.Location)
        .SingleOrDefaultAsync();

            if (@event == null)
            {
                return null!;
            }

            var details = new EventViewModel_Details
            {
                ProgramName = @event.Programme?.ProgramName,
                Time = $"{@event.StartDate.ToString("HH:mm")} - {@event.EndDate.ToString("HH:mm")}",
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                LocationTitle = @event.Location?.Title,
                Price = @event.Programme?.Price ?? 0,
                EventName = @event.EventCategory?.EventName,
                Content = @event.EventCategory?.Content
            };

            return details;


        }



        public async Task<List<EventViewModel_SalesTicket>> GetListShowSalesTicketAsync()
        {
            var events = await _context.Events!
            .Include(x => x.Programme)
            .Where(x => x.Programme!.Type_inoff == 2)
            .ToListAsync();

            return events.Select(x => new EventViewModel_SalesTicket
            {
                EventId = x.EventId,
                ProgramName = x.Programme?.ProgramName,
                StartDate = x.StartDate
            }).ToList();
        }
    public async Task<int> UpdateAsync(int id, EventViewModel_Add model)
        {
            try
            {
                var eventUpdate = await _context.Events!.FindAsync(id);

                if (eventUpdate == null)
                    return 1;

                eventUpdate.ProgramId = eventUpdate.ProgramId;
                eventUpdate.StartDate = eventUpdate.StartDate;
                eventUpdate.EndDate = eventUpdate.EndDate;
                eventUpdate.LocationId = eventUpdate.LocationId;
                eventUpdate.EventCategoryId = eventUpdate.EventCategoryId;

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

