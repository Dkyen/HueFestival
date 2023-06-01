using System;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.Controllers;

	
    public class TicketLocation
    {
        public int TicketLocationId { get; set; }

        [Required]
        [StringLength(255)]
        public string? TicketLocationName { get; set; }

        [Required]
        [StringLength(255)]
        public string? Address { get; set; }

        [Required]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string? Image { get; set; }
    }




