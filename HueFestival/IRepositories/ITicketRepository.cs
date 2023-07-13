using System;
using HueFestival.Models;
using HueFestival.ViewModel;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace HueFestival.Repositories
{
    public interface ITicketRepository
    {
        public Task<int> BuyTicketAsync(BuyTicketViewModel ticket, string userId);
        public Task<List<Ticket>> GetAllAsync();
        public Task<List<Ticket>> GetByUserId(string userId);
        public Task<Ticket?> GetByIdAsync(int ticketId);
    }
}








       

