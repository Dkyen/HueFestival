using System;
using HueFestival.Data;
using AutoMapper;
using HueFestival.ViewModel;
using HueFestival.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;
        public ProgramRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(ProgramViewModel_Add model)
        {
            Programme programme = new Programme
            {
                ProgramName = model.ProgramName,
                Content = model.Content,
                Type_inoff = model.Type_inoff,
                TypeProgram = model.TypeProgram,
                Price = model.Price,
            };

            _context.Set<Programme>().Add(programme);
            await _context.SaveChangesAsync();

            
        }
       
        public Task<bool> CheckProgrammeExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var programme = await _context.Set<Programme>().FindAsync(id);

                if (programme is null)
                    return 1;

                _context.Set<Programme>().Remove(programme);
                await _context.SaveChangesAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public async Task<List<Programme>> GetAll(int id)
        {
            var programme = await _context.Programmes!.Include(p => p.ListEvent!)
                                              .ThenInclude(p => p.Location)
                                              .SingleOrDefaultAsync(p => p.ProgramId == id);

            if (programme != null)
            {
                var programmeList = new List<Programme> { programme };
                return programmeList;
            }

            return new List<Programme>();
        }

        public async Task<List<ProgramViewModel>> GetAllAsync()
        {
            var programmes = await _context.Set<Programme>().ToListAsync();
            return programmes.Select(p => _mapper.Map<ProgramViewModel>(p)).ToList();
        }

        public async Task<List<ProgramViewModel>> GetAllByTypeProgram(int typeProgram)
        {
            var programmes = await _context.Set<Programme>()
            .Where(p => p.TypeProgram == typeProgram)
            .ToListAsync();

            return _mapper.Map<List<ProgramViewModel>>(programmes);
        }

        public async Task<List<Programme>> GetAllByTypeProgramAsync(int typeProgram)
        {
            return await _context.Programmes!
                 .Where(p => p.TypeProgram == typeProgram)
                 .ToListAsync();
        }

        

        public async Task<ProgramViewModel_Details> GetDetailsAsync(int id)
        {
            var programme = await _context.Programmes!.FindAsync(id);

            if (programme == null)
                return null!;

            await _context.Entry(programme)
               .Collection(lc => lc.ListEvent!)
                .LoadAsync();

            return _mapper.Map<ProgramViewModel_Details>(programme);
        }

        public async Task<int> UpdateAsync(int id, ProgramViewModel_Add model)
        {
            try
            {
                var programme = await _context.Set<Programme>().FindAsync(id);

                if (programme == null)
                    return 1;

                programme.ProgramName = model.ProgramName;
                programme.Content = model.Content;
                programme.Price = model.Price;
                programme.TypeProgram = model.TypeProgram;
                programme.Type_inoff = model.Type_inoff;

                _context.Set<Programme>().Update(programme);
                await _context.SaveChangesAsync();
                return 3;
            }
            
            catch
            {
                return 2;
            }
        }
    }
}