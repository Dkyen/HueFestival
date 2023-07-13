using System;
using AutoMapper;
using HueFestival.Models;
using HueFestival.ViewModel;
using HueFestival.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueFestival.IRepositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace HueFestival_OnlineTicket.Core.Service
{
    public class CheckInRepository:ICheckInRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public CheckInRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<dynamic> CheckInAsync(string code, string userId)
        {
            var ticket = await _context.Tickets!.FirstOrDefaultAsync(t => t.TicketNumber == code);

            if (ticket == null)
                return new { Message = "Vé không hợp lệ", Success = false };
            if (ticket.Status == true)
                return new { Message = "Vé đã check in trước đó", Success = false };
            ticket.Status = true;

            await _context.Checkins!.AddAsync(new Checkin
            {

                TicketId = ticket.TicketId,
                UserId = userId,
                Status = true,
                CreatedAt = DateTime.Now

            }) ;

            await _context.SaveChangesAsync();

            return new { Message = "Vé hợp lệ", Data = _mapper.Map<TicketViewModel>(ticket), Success = true };
        }

        public async Task<List<Checkin>> GetHistoryCheckIn(string? userId, DateTime? dateCheckIn, string? typeTicket, int? programmeId)
        {
            var listCheckIn = await _context.Checkins!
                .Where(x => x.UserId == userId)
                .Include(x => x.User)
                .Include(x => x.Ticket)
                .ThenInclude(x => x!.TypeTicket)
                 .ThenInclude(x => x!.Event)
                .ThenInclude(x => x!.Programme)
                .ToListAsync();
            bool date = dateCheckIn == null ? false : true;
            bool type = typeTicket == null || typeTicket == null ? false : true;
            bool programId = programmeId == null ? false : true;

            if (!date && !type && !programId)
            {
                return listCheckIn;
            }

            if (date && !type && !programId)
            {
               return listCheckIn.Where(x => x.CreatedAt.Date == dateCheckIn).ToList();
            }

            if (!date && type && !programId)
            {
                return listCheckIn.Where(x => x.Ticket!.TypeTicket!.Type == typeTicket)
                                  .ToList();
            }

            if (!date && !type && programId)
            {
                return listCheckIn.Where(x => x.Ticket!.TypeTicket!.Event!.Programme!.ProgramId == programmeId)
                                  .ToList();
            }
            if (!date && type && programId)
            {
                return listCheckIn.Where(x => x.Ticket!.TypeTicket!.Event!.Programme!.ProgramId == programmeId && x.Ticket.TypeTicket.Type == typeTicket)
                                  .ToList();
            }

            if (date && !type && programId)
            {
                return listCheckIn.Where(x => x.Ticket!.TypeTicket!.Event!.Programme!.ProgramId == programmeId && x.CreatedAt.Date == dateCheckIn)
                                  .ToList();
            }

            if (date && type && !programId)
            {
                return listCheckIn.Where(x => x.Ticket!.TypeTicket!.Type == typeTicket && x.CreatedAt.Date == dateCheckIn)
                                  .ToList();
            }

            return listCheckIn.Where(x => x.Ticket!.TypeTicket!.Event!.Programme!.ProgramId == programmeId &&
                                          x.CreatedAt.Date == dateCheckIn &&
                                          x.Ticket.TypeTicket.Type == typeTicket)
                              .ToList();
        }

        public async Task<List<CheckInViewModel_Report>> ReportAsync(string userId)
        {
            var query = _context.Checkins!
        .Include(x => x.Ticket)
        .ThenInclude(ticket => ticket!.TypeTicket)
        .ThenInclude(typeTicket => typeTicket!.Event)
        .ThenInclude(evt => evt!.Programme)
        .Where(x => x.UserId == userId)
        .GroupBy(x => x.Ticket!.TypeTicket!.Event!.Programme!.ProgramName)
        .Select(x => new CheckInViewModel_Report
        {
            EventName = x.Key,
            CountTicket = x.Count()
        });

            return await query.ToListAsync();

        }
    }
}
