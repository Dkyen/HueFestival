using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HueFestival.Models;
using HueFestival.IRepositories;
using HueFestival.Repositories;
using HueFestival.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HueFestival.Extensions;
using QRCoder;


namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepo;
       
       
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository ticketRepo, IMapper mapper)
        {
            _ticketRepo= ticketRepo;
            _mapper = mapper;
           
        }
        
        [Authorize(Roles = "User")]
        [HttpPost("buy_ticket")]
        public async Task<IActionResult> BuyTicket(BuyTicketViewModel ticket)
        {
            string userId = User.FindFirstValue("UserId");
              //  string userId = HttpContext.UserId();

            var result = await _ticketRepo.BuyTicketAsync(ticket, userId);

            switch (result)
             {
                 case 1:
                     return BadRequest("Vé không tồn tại");
                 case 2:
                     return BadRequest("Số lượng vé không đủ");
                 case 3:
                     return Ok("Mua thành công");
                 case 4:
                     return Problem(detail: "Đã sảy ra lỗi, vui lòng thử lại");
                 default:
                     return NoContent();
             }
         
        }

        [HttpGet("get_all_ticket")]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.Map<List<TicketViewModel>>(await _ticketRepo.GetAllAsync()));

        [Authorize(Roles = "User")]
        [HttpGet("get_list_purchased_tickets")]
        public async Task<IActionResult> GetByUserId()
        {
            string userId = User.FindFirstValue("UserId");
           // string userId = HttpContext.GetUserId();

            return Ok(_mapper.Map<List<TicketViewModel>>(await _ticketRepo.GetByUserId(userId)));
        }

        [HttpGet("get_qrcode_ticket")]
        public async Task<IActionResult> GetQRCodeTicket(int ticketId)
        {
            var ticket = await _ticketRepo.GetByIdAsync(ticketId);

            if (ticket is null)
                return NotFound();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket.TicketNumber, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(10);

            return File(qrCodeAsBitmapByteArr, "image/jpeg");
        }
    }
}

