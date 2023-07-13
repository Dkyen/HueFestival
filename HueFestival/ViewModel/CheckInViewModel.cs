using System;
namespace HueFestival.ViewModel
{
    public class CheckInViewModel
    {
        public string? TicketNumber { get; set; }
        public string? DateCheckIn { get; set; }
        public string? TypeTicket { get; set; }
        public string? UserCheckIn { get; set; }
        public double PriceTicket { get; set; }
        public bool Status { get; set; }
    }

    public class CheckInViewModel_Report
    {
        public string? EventName { get; set; }
        public int CountTicket { get; set; }
    }
}

