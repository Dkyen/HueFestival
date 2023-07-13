using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HueFestival.Models;
using HueFestival.IRepositories;
using HueFestival.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class CheckinController : ControllerBase
    {
        private readonly ICheckInRepository _checkinRepo;
        private readonly IMapper _mapper;

        public CheckinController(ICheckInRepository checkinRepo, IMapper mapper)
        {
            _checkinRepo = checkinRepo;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("check_in")]
        public async Task<IActionResult> CheckIn(string code)
        {
            string userId = User.FindFirstValue("UserId");
           
            var resultCheckIn = await _checkinRepo.CheckInAsync(code, userId);

            return Ok(resultCheckIn);
        }

        [Authorize]
        [HttpGet("report")]
        public async Task<IActionResult> Report()
        {
            string userId = User.FindFirstValue("UserId");

            return Ok(await _checkinRepo.ReportAsync(userId));
        }

        [Authorize]
        [HttpGet("get_history_check_in")]
        public async Task<IActionResult> GetCheckinHistory(DateTime? date, int? programmeId, string? typeTicket)
        {
            string userId = User.FindFirstValue("UserId");
         
            return Ok(_mapper.Map<List<CheckInViewModel>>(await _checkinRepo.GetHistoryCheckIn(userId, date, typeTicket, programmeId)));
        }
    }
}

