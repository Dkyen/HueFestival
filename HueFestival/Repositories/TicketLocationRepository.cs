using System;
using HueFestival.IRepositories;
using HueFestival.Data;
using HueFestival.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HueFestival.Models;

namespace HueFestival.Repositories
{
	public class TicketLocationRepository :ITicketLocationRepository
	{
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public TicketLocationRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddASync(TicketLocationViewModel_Add model)
        {
            var ticketLocation = _mapper.Map<TicketLocation>(model);
            _context.TicketLocations!.Add(ticketLocation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticketLocation = await _context.TicketLocations!.FindAsync(id);

            if (ticketLocation is null)
                return false;

            _context.Set<TicketLocation>().Remove(ticketLocation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<TicketLocationViewModel>> GetAllAsync()
        {
            var ticketLocations = await _context.TicketLocations!.ToListAsync();
            return _mapper.Map<List<TicketLocationViewModel>>(ticketLocations);
        }

        public async Task<bool> UpdateAsync(int id, TicketLocationViewModel_Add model)
        {
            var ticketLocation = await _context.TicketLocations!.FindAsync(id);

            if (ticketLocation is null)
                return false;

            ticketLocation.TicketLocationName = model.TicketLocationName;
            ticketLocation.PhoneNumber = model.PhoneNumber;
            ticketLocation.Address = model.Address;
            ticketLocation.Image = model.Image;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

