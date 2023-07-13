using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HueFestival.Models;

namespace HueFestival.ViewModel
{
    public class TicketTypeViewModel
    {
        public int TypeTicketId { get; set; }
        public string? Type { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public class TicketTypeViewModel_Add
    {
        public int EventId { get; set; }
        public string? Type { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}

