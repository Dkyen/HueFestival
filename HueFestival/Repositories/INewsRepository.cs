using System;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;

namespace HueFestival.Repositories
{
	public interface INewsRepository
	{

        public Task<List<NewsViewModel>> GetAllNewsAsyn();
        public Task<NewsViewModel> GetNewsAsyn(int id);
        public Task<int> AddNewsAsyn(NewsViewModel model);
        public Task UpdateNewsAsyn(int id, NewsViewModel model);
        public Task DeleteNewsAsyn(int id);


    }
}

