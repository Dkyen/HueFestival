using System;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.ViewModel
{
    public class TicketLocationViewModel
    {
        public int TicketLocationId { get; set; }

        public string? TicketLocationName { get; set; }

        public string? Address { get; set; }

        [RegularExpression("0\\d{9}", ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        public string? Image { get; set; }
    }

    public class TicketLocationViewModel_Add
    {
        [Required]
        public string? TicketLocationName { get; set; }

        [Required]
        public string? Address { get; set; }

        [RegularExpression("0\\d{9}", ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Image { get; set; }
    }
}

