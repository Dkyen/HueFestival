using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HueFestival.Models
{
    [Table("TicketLocation")]
    public class TicketLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketLocationId { get; set; }

        [Required]
        public string? TicketLocationName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Image { get; set; }
    }
}
