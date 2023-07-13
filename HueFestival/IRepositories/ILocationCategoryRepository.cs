using System;
using HueFestival.ViewModel;
using HueFestival.Models;

namespace HueFestival.IRepositories
{
	public interface ILocationCategoryRepository
	{
        public Task<bool> CheckExistAsync(int id);
        public Task<List<LocationCategoryViewModel>> GetAllAsync();
        public Task<LocationCategoryViewModel_Details> GetByIdAsync(int id);
        public Task AddAsync(LocationCategoryViewModel_Add model);
        public Task<bool> UpdateAsync(int id, LocationCategoryViewModel_Add model);
        public Task<bool> DeleteAsync(int id);
        public Task<LocationCategory> GetById(int id);
    }
}

