using System;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
	public interface IAboutRepository
	{
        public Task AddAsync(AboutViewModel_Add model);
        public Task<bool> DeleteAsync(int id);
        public Task<List<AboutViewModel>> GetAllAsync();
        public Task<AboutViewModel_Details> GetDetailsAsync(int id);
        public Task<bool> UpdateAsync(int id, AboutViewModel_Add input);
        

    }
}

