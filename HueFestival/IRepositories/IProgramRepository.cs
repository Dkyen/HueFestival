using System;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
	public interface IProgramRepository
	{
        public Task AddAsync(ProgramViewModel_Add input);
        public Task<int> DeleteAsync(int id);
        public Task<List<ProgramViewModel>> GetAllByTypeProgram(int typeProgram);
        public Task<ProgramViewModel_Details> GetDetailsAsync(int id);
        public Task<int> UpdateAsync(int id, ProgramViewModel_Add model);
        public Task<List<ProgramViewModel>> GetAllAsync();
        public Task<bool> CheckProgrammeExistAsync(int id);
        public Task<List<Programme>> GetAllByTypeProgramAsync(int typeProgram);
        public Task<List<Programme>> GetAll(int id);
       

    }
   
}

