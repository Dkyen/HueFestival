using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HueFestival.Models
{
    [Table("PriceTicket")]
    public class PriceTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriceTicketId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int NumberSlot { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; }

        [ForeignKey("TypeTicket")]
        public int TypeTicketId { get; set; }
        public TypeTicket? TypeTicket { get; set; }
    }
}
