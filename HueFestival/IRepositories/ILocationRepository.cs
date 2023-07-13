using System;
using HueFestival.ViewModel;
using HueFestival.Models;
namespace HueFestival.IRepositories
{
	public interface ILocationRepository
	{
        public Task <Location> GetById(int id);
        public Task <LocationViewModel_Details> GetLocationAsync(int id);
        public Task <Location> AddLocationAsync(LocationViewModel_Add model);
        public Task <bool> UpdateLocationAsync(int id, LocationViewModel_Add model);
        public Task <bool>DeleteLocationAsync(int id);
       

    }
}

