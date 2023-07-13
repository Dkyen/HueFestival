using System;
using HueFestival.ViewModel;
using HueFestival.Models;
using HueFestival.Data;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.IRepositories
{
	public interface ITypeTicketRepository
    {

        public Task AddAsync(TypeTicket ticketType);

        public Task DeleteAsync(TypeTicket ticketType);

        public Task<List<TypeTicket>> GetAllAsync();

        public Task<TypeTicket?> GetByIdAsync(int id);

        public Task<List<TypeTicket>> GetByEventIdAsync(int eventId);

        public Task UpdateAsync(TypeTicket ticketType);
      

    }
}

