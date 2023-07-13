using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HueFestival.Data;
using HueFestival.Models;
using HueFestival.ViewModel;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Microsoft.Extensions.Logging;
using static QRCoder.PayloadGenerator.SwissQrCode;
using System.Net.Sockets;
using HueFestival.IRepositories;
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace HueFestival.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly HueFestivalContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(HueFestivalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public async Task<int> BuyTicketAsync(BuyTicketViewModel ticket, string userId)
        {
            try
            {
                var ticketType = await _context.TypeTickets!.FindAsync(ticket.TypeTicketId);

                if (ticketType == null)
                    return 1;

                if (ticketType.Quantity < ticket.Quantity)
                    return 2;

                ticketType.Quantity -= ticket.Quantity;

                _context.TypeTickets.Update(ticketType);
                await _context.SaveChangesAsync();

                var createdDate = DateTime.Now;
                for (int i = 0; i < ticket.Quantity; i++)
                {
                    await _context.Tickets!.AddAsync(new Ticket
                    {
                        TypeTicketId = ticket.TypeTicketId,
                        UserId = userId,
                        CreatedAt = createdDate,
                        Status = false,
                        TicketNumber = GenerateCode()
                    });
                }

                await _context.SaveChangesAsync();

                return 3;
            }
            catch
            {
                return 4;
            }

        }
        private byte[] GenerateQRCode(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(10);

            return qrCodeAsBitmapByteArr;
        }

        private string GenerateCode()
        {
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            int stringlen = rand.Next(20, 30);
            string code = "";

            for (int i = 0; i < stringlen; i++)
            {
                int x = rand.Next(chars.Length);
                code += chars[x];
            }

            if (CheckCode(code))
            {
                code = GenerateCode();
            }

            return code;
        }

        public bool CheckCode(string code)
        {

            return _context.Tickets!.Any(t => t.TicketNumber == code);

        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets!.ToListAsync();

        }



        public async Task<Ticket?> GetByCode(string code)
        {
            return await _context.Tickets!
        .Include(t => t.TypeTicket)
        .ThenInclude(t => t!.Event)
        .ThenInclude(t => t!.Programme)
        .Where(t => t.TicketNumber!.Equals(code))
        .SingleOrDefaultAsync();

        }

        public async Task<List<Ticket>> GetByUserId(string userId)
        {
            var tickets = await _context.Tickets!.Include(t => t.TypeTicket).ThenInclude(t => t.Event).ThenInclude(t => t.Programme)
                                    .Where(t => t.UserId == userId).ToListAsync();
            return tickets;
        }

        public async Task<Ticket?> GetByIdAsync(int ticketId)
        {
          
            var ticket = await _context.Tickets!.FindAsync(ticketId);
            return _mapper.Map<Ticket>(ticket);
        }
    }
}
