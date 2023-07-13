using System;
using HueFestival.Models;
using HueFestival.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.IRepositories
{
	public interface ICheckInRepository
	{
        public Task<dynamic> CheckInAsync(string code, string userId);
        public Task<List<Checkin>> GetHistoryCheckIn(string? userId, DateTime? dateCheckIn, string? typeTicket, int? programmeId);
        public Task<List<CheckInViewModel_Report>> ReportAsync(string userId);
       
    }
}

