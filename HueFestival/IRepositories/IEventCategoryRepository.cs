using System;
using HueFestival.ViewModel;
namespace HueFestival.IRepositories
{
	public interface IEventCategoryRepository
	{
        public Task<int> AddAsync(EventCategoryViewModel_Add model);
        public  Task<int> DeleteAsync(int id);
        public Task<List<EventCategoryViewModel>> GetAllAsync();
        public Task<int> UpdateAsync(int id, EventCategoryViewModel_Add model);
     }
}


