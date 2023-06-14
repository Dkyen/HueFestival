/*using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HueFestival.Models;
using HueFestival.ViewModel;
using HueFestival.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public AboutService(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAboutAsync(AboutViewModel model)
        {
            var Newabout = _mapper.Map<About>(model);
            return await _aboutRepository.AddAboutAsyn(Newabout);
        }

        public async Task DeleteAboutAsync(int id)
        {
            await _aboutRepository.DeleteAboutAsync(id);
        }

        public async Task<AboutViewModel> GetAboutAsync(int id)
        {
            var about = await _aboutRepository.GetAboutAsync(id);
            return _mapper.Map<AboutViewModel>(about);
        }

        public async Task<List<AboutViewModel>> GetAllAboutsAsync()
        {
            var abouts = await _aboutRepository.GetAllAboutsAsync();
            return _mapper.Map<List<AboutViewModel>>(abouts);
        }

        public async Task UpdateAboutAsync(int id, AboutViewModel model)
        {
            var about = _mapper.Map<About>(model);
            await _aboutRepository.UpdateAboutAsync(id, about);
        }
    }
}
*/