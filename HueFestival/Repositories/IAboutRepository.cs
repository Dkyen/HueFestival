using System;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;
namespace HueFestival.Repositories
{
	public interface IAboutRepository
	{
		public Task<List<AboutViewModel>> GetAllAboutsAsyn();
		public Task<AboutViewModel> GetAboutsAsyn(int id);
		public Task<int> AddAboutAsyn(AboutViewModel model);
		public Task UpdateAboutAsyn(int id, AboutViewModel model);
        public Task DeleteAboutsAsyn(int id);
       
    }
}

