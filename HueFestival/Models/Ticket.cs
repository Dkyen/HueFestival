using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace HueFestival.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

       
        public string? TicketNumber { get; set; }
        
        public int TypeTicketId { get; set; }

       
        public TypeTicket? TypeTicket { get; set; }

        
        public bool Status { get; set; }

       
        public DateTime CreatedAt { get; set; }

       
        public string? UserId { get; set; }
       
        public User? User { get; set; }

    }
    


}
