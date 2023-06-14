using System.Collections.Generic;
using System.Threading.Tasks;
using HueFestival.Models;
using HueFestival.ViewModel;

namespace HueFestival.Services
{
    public interface IAboutService
    {
        Task<List<AboutViewModel>> GetAllAboutsAsync();
        Task<AboutViewModel> GetAboutAsync(int id);
        Task<int> AddAboutAsyncs(AboutViewModel model);
        Task UpdateAboutAsync(int id, AboutViewModel model);
        Task DeleteAboutAsync(int id);
    }
}


