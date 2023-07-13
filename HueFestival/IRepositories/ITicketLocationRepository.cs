using System;
using HueFestival.Models;
using HueFestival.ViewModel;

namespace HueFestival.IRepositories
{
	public interface ITicketLocationRepository
	{
        public Task AddASync(TicketLocationViewModel_Add model);
        public Task<bool> DeleteAsync(int id);
        public Task<List<TicketLocationViewModel>> GetAllAsync();
        public Task<bool> UpdateAsync(int id, TicketLocationViewModel_Add model);
    }
}

