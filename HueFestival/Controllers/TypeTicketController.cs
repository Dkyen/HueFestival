using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HueFestival.IRepositories;
using HueFestival.Data;
using HueFestival.ViewModel;
using HueFestival.Models;


namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    public class TypeTicketController : ControllerBase
    {

        private readonly ITypeTicketRepository _typeTicketRepo;

        private readonly IMapper _mapper;


        public TypeTicketController(ITypeTicketRepository typeTicketRepo, IMapper mapper)
        {
            _typeTicketRepo = typeTicketRepo;
            _mapper = mapper;
        }

        [HttpPost("add_ticket_type")]
        public async Task<IActionResult> Add(TicketTypeViewModel_Add input)
        {
            var mapInput = _mapper.Map<TypeTicket>(input);

           
            await _typeTicketRepo.AddAsync(mapInput);

            return Ok("Thêm thành công");
        }

        [HttpGet("get_by_event")]
        public async Task<IActionResult> GetByEventId(int id)
            => Ok(_mapper.Map<List<TicketTypeViewModel>>(await _typeTicketRepo.GetByEventIdAsync(id)));

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.Map<List<TicketTypeViewModel>>(await _typeTicketRepo.GetAllAsync()));

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, TicketTypeViewModel_Add input)
        {
            var ticketType = await _typeTicketRepo.GetByIdAsync(id);

            if (ticketType == null)
                return NotFound();

            await _typeTicketRepo.UpdateAsync(_mapper.Map(input, ticketType));

            return Ok("Cập nhật thành công");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticketType = await _typeTicketRepo.GetByIdAsync(id);

            if (ticketType == null)
                return NotFound();

            await _typeTicketRepo.DeleteAsync(ticketType);

            return Ok("Xoá thành công");
        }
    }
}

