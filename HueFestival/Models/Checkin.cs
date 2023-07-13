using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HueFestival.Models
{
    [Table("Checkin")]
    public class Checkin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckinId { get; set; }

        [Required]
        public int TicketId { get; set; }
        public string? UserId { get; set; }

        public bool? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("TicketId")]
        public Ticket? Ticket { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

    }
}

