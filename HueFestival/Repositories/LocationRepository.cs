using AutoMapper;
using HueFestival.Models;
using HueFestival.Data;
using HueFestival.Repositories;
using HueFestival.ViewModel;
using HueFestival.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public LocationRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Location> AddLocationAsync(LocationViewModel_Add model)
        {
            
            Location location = new Location
            {
                LocationCategoryId = model.LocationCategoryId,
                Title = model.Title,
                Content = model.Content,
                Image = model.Image,
                Longtitude = model.Longtitude,
                Latitude = model.Latitude

            };
            _context.Locations!.Add(location);
            await _context.SaveChangesAsync();
            return location;

        }
       

        public async Task <bool> DeleteLocationAsync(int id)
        {
            var location = await _context.Locations!.FindAsync(id);

            if (location is null)
                return false;

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Location> GetById(int id)
        {
            var location = await _context.Locations!.FindAsync(id);
            return _mapper.Map<Location>(location);
        }

        public async Task<LocationViewModel_Details> GetLocationAsync(int id)

      

         

        {
            var location = await _context.Locations!.FindAsync(id);

            if (location == null)
            {
                return null!;
            }

            await _context.Entry(location)
                .Reference(l => l.LocationCategory)
                .LoadAsync();

            var locationDetails = new LocationViewModel_Details
            {
                LocationId = location.LocationId,
                LocationCategory = location.LocationCategory?.Title,
                Title = location.Title,
                Content = location.Content,
                Image = location.Image,
                Longtitude = location.Longtitude,
                Latitude = location.Latitude
            };

            return locationDetails;
        }



        public async Task<bool> UpdateLocationAsync(int id, LocationViewModel_Add model)
        {
            var location = await _context.Locations!.FindAsync(id);

            if (location is null)
                return false;

            var locationCategoryExist = await _context.LocationCategories!.AnyAsync(lc => lc.LocationCategoryId == model.LocationCategoryId);

            if (!locationCategoryExist)
                return false;

            location.LocationCategoryId = model.LocationCategoryId;
            location.Title = model.Title;
            location.Content = model.Content;
            location.Latitude = model.Latitude;
            location.Longtitude = model.Longtitude;
            location.Image = model.Image;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
