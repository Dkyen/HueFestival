using System;
using System.ComponentModel.DataAnnotations;
namespace HueFestival.ViewModel
{
	public class TicketViewModel
	{
        public int TicketId { get; set; }

        public string? TicketNumber { get; set; }

        public int EventId { get; set; }

        public string? EventName { get; set; }

        public string? Day { get; set; }

        public string? Time { get; set; }

        public string? Type { get; set; }

        public double Price { get; set; }

        public string? Status { get; set; }
    }
    public class BuyTicketViewModel
    {
        public int TypeTicketId { get; set; }

        public int Quantity { get; set; }

       
    }
}

