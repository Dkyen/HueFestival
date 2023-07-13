using System;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;

namespace HueFestival.Repositories
{
	public interface INewsRepository
	{

        public Task AddAsync(NewsViewModel_Add model);
        public Task<bool> DeleteAsync(int id);
        public Task<List<NewsViewModel>> GetAllAsync();
        public Task<NewsViewModel_Details> GetDetailsAsync(int id);
        public Task<bool> UpdateAsync(int id, NewsViewModel_Add input);

    }
}

