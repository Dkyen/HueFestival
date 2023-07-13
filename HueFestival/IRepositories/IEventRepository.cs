using System;
using HueFestival.ViewModel;
using HueFestival.Models;

namespace HueFestival.Repositories
{
	public interface IEventRepository
	{
        public Task<List<EventViewModel_SalesTicket>> GetListShowSalesTicketAsync();
        public Task<int> AddAsync(EventViewModel_Add model);
        public Task<int> DeleteAsync(int id);
        public Task<IEnumerable<dynamic>> GetCalendarList();
        public Task<List<EventViewModel>> GetByDate(DateTime date);
        public Task<int> UpdateAsync(int id, EventViewModel_Add model);
        public Task<EventViewModel_Details> GetDetailsAsync(int id);
        public Task<List<EventViewModel>> GetAllAsync();
      

    }
}
