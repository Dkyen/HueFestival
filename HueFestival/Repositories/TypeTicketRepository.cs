using System;
using AutoMapper;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;
using HueFestival.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;


namespace HueFestival.Repositories
{
    public class TypeTicketRepository : ITypeTicketRepository
    {
        private readonly HueFestivalContext _context;
      

        public TypeTicketRepository(HueFestivalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TypeTicket ticketType)
        {
            await _context.TypeTickets!.AddAsync(ticketType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TypeTicket ticketType)
        {
            _context.TypeTickets!.Remove(ticketType);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TypeTicket>> GetAllAsync()
        {
            return await _context.TypeTickets!.ToListAsync();
        }
        public async Task<TypeTicket?> GetByIdAsync(int id)
        {
            return await _context.TypeTickets!.FindAsync(id);
        }


        public async Task<List<TypeTicket>> GetByEventIdAsync(int eventId)
        {
            return await _context.TypeTickets!
                .Where(t => t.EventId == eventId)
                .ToListAsync();
        }

        public async Task UpdateAsync(TypeTicket ticketType)
        {
            _context.TypeTickets!.Update(ticketType);
            await _context.SaveChangesAsync();
        }
    }
}   